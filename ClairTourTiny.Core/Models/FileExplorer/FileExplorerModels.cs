namespace ClairTourTiny.Core.Models.FileExplorer
{
    // ... existing model classes ...

    /// <summary>
    /// Represents details of an available Dropbox invitee
    /// </summary>
    public class DropboxInviteeDetails
    {
        /// <summary>
        /// The name of the invitee
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the invitee
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The access level ID for the invitee
        /// </summary>
        public int AccessLevelId { get; set; }

        /// <summary>
        /// The description of the access level
        /// </summary>
        public string AccessLevelDescription { get; set; }
    }
} 