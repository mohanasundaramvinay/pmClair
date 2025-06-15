using ClairTourTiny.Infrastructure.Models.FileExplorer;

namespace ClairTourTiny.Core.Helpers
{
    public class FileStorageHelper
    {
        public string GetAttachmentTypesQuery(string attachmentCategory)
        {
            return $@"          
WITH RankedRows AS (
    SELECT act.AttachmentCategory, at.AttachmentTypeDescription, Permissionsneeded = is_rolemember(DatabaseRole), act.AttachmentType, atb.DatabaseRole,
					                 CASE ISNULL (is_rolemember(DatabaseRole), 1)
					                 WHEN 0 THEN 0
					                 ELSE 1
					                 END AS hasPermissions, at.CanHaveExpirationDate, at.Parent, dbo.fn_get_attachmentTypeFullPath(at.AttachmentType) AS FullAttachmentTypePath
                        ,at.TreeOrder, ROW_NUMBER() OVER (PARTITION BY act.AttachmentType, at.AttachmentTypeDescription, at.Parent, at.TreeOrder, dbo.fn_get_attachmentTypeFullPath(at.AttachmentType) 
                   ORDER BY atb.DatabaseRole) AS rn                 
                        FROM dbo.AttachmentCategoryTypes act
                         JOIN dbo.AttachmentTypes at ON act.AttachmentType = at.AttachmentType
					                 LEFT OUTER JOIN dbo.AttachmentTypeDatabaseRoles atb ON atb.AttachmentType = at.AttachmentType
                         WHERE act.AttachmentCategory =  '{attachmentCategory}'
)
SELECT 
    AttachmentType,
    AttachmentTypeDescription,
    FullAttachmentTypePath,
    Parent,
    TreeOrder,
    AttachmentCategory,
    DatabaseRole,
    Permissionsneeded,
    CanHaveExpirationDate,
    hasPermissions
FROM RankedRows
WHERE rn = 1
ORDER BY Parent, TreeOrder;";
        }
    }
}
