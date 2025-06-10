using ClairTourTiny.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ClairTourTiny.Infrastructure.Models.FileExplorer;
using ClairTourTiny.Core.Models.FileExplorer;



namespace ClairTourTiny.Core.Services
{
    public class FileExplorerService : IFileExplorerService
    {
        private readonly string _connectionString;
        private readonly ILogger<FileExplorerService> _logger;

        public FileExplorerService(IConfiguration configuration, ILogger<FileExplorerService> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<AttachmentCategoryDetails> GetAttachmentCategoryDetailsAsync(string attachmentCategory)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT ac.AttachmentCategory, 
                       ac.attachmentsCanBeInKnowledgeBase, 
                       is_rolemember('KnowledgeBaseEditors') as CanEditKnowledgeBase, 
                       ac.defaultRootFolderPath
                FROM dbo.AttachmentCategory AS ac
                WHERE AttachmentCategory = @AttachmentCategory";

            var result = await connection.QueryFirstOrDefaultAsync<AttachmentCategoryDetails>(sql, new { AttachmentCategory = attachmentCategory });
            return result;
        }

        public async Task<string> GetFavoritesFolderNameAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT s.Value 
                FROM dbo.SysConfig s
                WHERE s.Tag = 'FINEESSE_FILE_STORAGE_FAVORITES_FOLDER_NAME'";

            return await connection.QueryFirstOrDefaultAsync<string>(sql);
        }

        public async Task<List<AttachmentTypeDetails>> GetAttachmentTypesAsync(string attachmentCategory)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT act.AttachmentCategory, 
                       at.AttachmentTypeDescription, 
                       Permissionsneeded = is_rolemember(DatabaseRole), 
                       act.AttachmentType, 
                       atb.DatabaseRole,
                       CASE ISNULL(is_rolemember(DatabaseRole), 1)
                           WHEN 0 THEN 0
                           ELSE 1
                       END AS hasPermissions, 
                       at.CanHaveExpirationDate, 
                       at.Parent, 
                       dbo.fn_get_attachmentTypeFullPath(at.AttachmentType) AS FullAttachmentTypePath,
                       at.TreeOrder
                FROM dbo.AttachmentCategoryTypes act
                JOIN dbo.AttachmentTypes at ON act.AttachmentType = at.AttachmentType
                LEFT OUTER JOIN dbo.AttachmentTypeDatabaseRoles atb ON atb.AttachmentType = at.AttachmentType
                WHERE act.AttachmentCategory = @AttachmentCategory
                ORDER BY Parent, TreeOrder";

            var results = await connection.QueryAsync<AttachmentTypeDetails>(sql, new { AttachmentCategory = attachmentCategory });
            return results.ToList();
        }

        public async Task<List<GroupPermissionDetails>> GetGroupPermissionsAsync(string attachmentCategory)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT gp.groupName, 
                       gp.AttachmentType, 
                       gp.allowFullControl, 
                       gp.allowModify, 
                       gp.[allowRead&Execute], 
                       gp.allowListFolderContents, 
                       gp.allowRead, 
                       gp.allowWrite, 
                       gp.allowSpecialPermissions, 
                       fpg.GroupPath
                FROM dbo.GroupPermissions gp
                JOIN dbo.FilePermissionsGroups fpg ON fpg.GroupName = gp.GroupName
                JOIN dbo.AttachmentCategoryTypes act ON act.AttachmentType = gp.AttachmentType
                WHERE act.AttachmentCategory = @AttachmentCategory";

            var results = await connection.QueryAsync<GroupPermissionDetails>(sql, new { AttachmentCategory = attachmentCategory });
            return results.ToList();
        }

        public async Task<CloudStorageInfo> GetCloudStorageInfoAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var dropboxRootDir = await connection.QueryFirstOrDefaultAsync<string>(
                "SELECT s.Value FROM dbo.SysConfig s WHERE s.Tag = 'DROPBOX_ROOT_DIRECTORY'");

            if (string.IsNullOrEmpty(dropboxRootDir))
                return new CloudStorageInfo { IsEnabled = false };

            var egnyteUri = await connection.QueryFirstOrDefaultAsync<string>(@"
                SELECT s.ServerURIPrefix
                FROM dbo.EgnyteSharingServers s
                WHERE s.ServerName = @@SERVERNAME");

            return new CloudStorageInfo
            {
                IsEnabled = true,
                DropboxRootDirectory = dropboxRootDir,
                EgnyteSharingURI = egnyteUri
            };
        }

        public async Task<List<CloudStorageTemplateDetails>> GetCloudStorageTemplatesAsync(string attachmentCategory)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT at.AttachmentTypeDescription, 
                       cfsgtat.AttachmentType, 
                       cfsgtat.CloudFolderTemplate, 
                       cfspft.DropboxFilePathSuffix
                FROM dbo.CloudFileStorageGroupsToAttachmentTypes AS cfsgtat
                JOIN dbo.CloudFileStoragePermissionFolderTemplate AS cfspft 
                    ON cfspft.CloudFolderTemplate = cfsgtat.CloudFolderTemplate
                JOIN dbo.AttachmentTypes AS at 
                    ON at.AttachmentType = cfsgtat.AttachmentType
                JOIN dbo.AttachmentCategoryTypes AS act 
                    ON act.AttachmentType = cfsgtat.AttachmentType
                WHERE act.AttachmentCategory = @AttachmentCategory";

            var results = await connection.QueryAsync<CloudStorageTemplateDetails>(sql, new { AttachmentCategory = attachmentCategory });
            return results.ToList();
        }

        public async Task<List<CloudFolderTemplateLevel>> GetCloudFolderTemplatesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT cfsgtpf.CloudFolderTemplate, 
                       cfsgtpf.id_Level 
                FROM dbo.CloudFileStorageGroupsToPermissionFolders AS cfsgtpf";

            var results = await connection.QueryAsync<CloudFolderTemplateLevel>(sql);
            return results.ToList();
        }

        public async Task<List<ContactCategoryCloudMapping>> GetContactCategoryCloudMappingsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT cc2g.id_ContactCategory,
                       cc2g.id_Level,
                       cc.ContactCategory,
                       g.[Level Description],
                       pf.CloudFolderTemplate 
                FROM dbo.ContactCategoriesCloudFileStorageGroups cc2g
                JOIN dbo.ContactCategory cc 
                    ON cc2g.id_ContactCategory = cc.id_ContactCategory
                JOIN dbo.CloudFileStorageGroups g 
                    ON cc2g.id_Level = g.id_Level
                JOIN dbo.CloudFileStorageGroupsToPermissionFolders pf 
                    ON g.id_Level = pf.id_Level";

            var results = await connection.QueryAsync<ContactCategoryCloudMapping>(sql);
            return results.ToList();
        }

        public async Task<List<RootAttachmentType>> GetRootAttachmentTypesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT cfspft.CloudFolderTemplate, 
                       cfspft.DropboxFilePathSuffix 
                FROM dbo.CloudFileStoragePermissionFolderTemplate AS cfspft";

            var results = await connection.QueryAsync<RootAttachmentType>(sql);
            return results.ToList();
        }

        public async Task<List<FileIndexDetails>> GetFileIndexAsync(Guid guid)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT fai.fileName, 
                       fai.fileExtension, 
                       fai.CreationTimeUtc, 
                       fai.GUID, 
                       fai.SubFolderPath, 
                       fai.fileNameUnique, 
                       fai.entityno, 
                       fai.partno, 
                       fai.empno, 
                       fai.unique_no, 
                       fai.CreatedBy, 
                       fai.topic, 
                       fai.IsInKnowledgeBase, 
                       fai.DocumentExpirationDateUTC
                FROM dbo.FileAttachmentIndex AS fai
                WHERE fai.GUID = @Guid";

            var results = await connection.QueryAsync<FileIndexDetails>(sql, new { Guid = guid });
            return results.ToList();
        }

        public async Task<List<CloudFileUploadDetails>> GetCloudFileUploadsAsync(string attachmentCategory, string entityNo, string partNo)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string sql;
            object parameters;

            if (attachmentCategory == "Projects")
            {
                sql = @"
                    SELECT cfsuf.fileName, 
                           cfsuf.entityno, 
                           cfsuf.isUploaded, 
                           cfsuf.dropboxFileID, 
                           cfsuf.uploadTime, 
                           cfsuf.AttachmentType, 
                           cfsuf.AttachmentCategory, 
                           cfsuf.UserFolderPath,
                           NULL as PartNo
                    FROM dbo.CloudFileStorageUploadedFiles AS cfsuf
                    WHERE cfsuf.entityno = @EntityNo";
                parameters = new { EntityNo = entityNo };
            }
            else // Parts
            {
                sql = @"
                    SELECT pf.fileName, 
                           NULL as EntityNo,
                           pf.isUploaded, 
                           pf.dropboxFileID, 
                           NULL as UploadTime,
                           NULL as AttachmentType,
                           'Parts' as AttachmentCategory,
                           pf.UserFolderPath,
                           pf.partno as PartNo
                    FROM dbo.CloudFileStorageUploadedPartFiles pf
                    WHERE pf.partno = @PartNo";
                parameters = new { PartNo = partNo };
            }

            var results = await connection.QueryAsync<CloudFileUploadDetails>(sql, parameters);
            return results.ToList();
        }

        public async Task<List<UserFolderDetails>> GetUserFoldersAsync(string entityNo)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT puftcsf.entityno, 
                       puftcsf.UserFolderPath, 
                       puftcsf.dropboxFolderID, 
                       puftcsf.CloudFolderTemplate, 
                       puftcsf.AttachmentType, 
                       puftcsf.id_Level, 
                       cfspft.CloudFolderTemplate, 
                       cfspft.DropboxFilePathSuffix 
                FROM dbo.ProjectsUsersFoldersToCloudStorageFolders AS puftcsf
                JOIN dbo.CloudFileStoragePermissionFolderTemplate AS cfspft 
                    ON cfspft.CloudFolderTemplate = puftcsf.CloudFolderTemplate
                WHERE puftcsf.entityno = @EntityNo";

            var results = await connection.QueryAsync<UserFolderDetails>(sql, new { EntityNo = entityNo });
            return results.ToList();
        }

        public async Task<List<ProjectShareRequestDetails>> GetProjectShareRequestsAsync(string entityNo)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                WITH available AS (
                    SELECT c.contactname as Name, 
                           c.email, 
                           cccfsg.id_Level  
                    FROM dbo.ProjectClientContacts pcc  
                    JOIN dbo.ContactCategory cc 
                        ON pcc.id_ContactCategory = cc.id_ContactCategory  
                    JOIN dbo.contacts c 
                        ON pcc.ContactNo = c.contactno
                    JOIN dbo.ContactCategoriesCloudFileStorageGroups AS cccfsg 
                        ON cccfsg.id_ContactCategory = cc.id_ContactCategory  
                    WHERE (pcc.entityno = @EntityNo OR pcc.entityno LIKE @EntityNo + '-%')
                    UNION
                    SELECT Name = e.firstname + ' ' + e.lastname, 
                           e.email, 
                           id_level = 3   --all confirmed crew are an ID level of 3   
                    FROM dbo.pjempassign a  
                    JOIN dbo.pejob j 
                        ON a.jobtype = j.jobtype AND j.is_qualification = 1  
                    JOIN dbo.glentities g 
                        ON a.entityno = g.entityno AND g.engactivecd <> 'I' 
                    JOIN dbo.peemployee e 
                        ON a.empno = e.empno  
                    WHERE a.StatusCode = 'A' 
                        AND (a.entityno = @EntityNo OR a.entityno LIKE @EntityNo + '-%')
                    UNION
                    SELECT TeamMemberName as Name, 
                           email, 
                           id_Level
                    FROM dbo.fn_GetProjectCoreTeam(@EntityNo)
                    JOIN dbo.CloudFileStoragGroupsToCoreTeam 
                        ON CoreTeamMemberDesc = TeamMemberRole
                )
                SELECT a.name as Name, 
                       c.email as Email, 
                       c.CloudFolderTemplate, 
                       c.isRemoveFolderMember, 
                       c.isAddFolderMember
                FROM available a
                RIGHT OUTER JOIN dbo.CloudFileStorageShareRequests c 
                    ON c.email = a.email
                WHERE c.entityno = @EntityNo";

            var results = await connection.QueryAsync<ProjectShareRequestDetails>(sql, new { EntityNo = entityNo });
            return results.ToList();
        }
    
       public async Task<List<DropboxInviteeDetails>> GetDropboxInviteesAsync(string entityNo)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = "dbo.get_fileExplorer_Dropbox_Invitees";
            var parameters = new { entityno = entityNo };

            var results = await connection.QueryAsync<DropboxInviteeDetails>(
                sql,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);

            return results.ToList();
        }
    
    }
} 