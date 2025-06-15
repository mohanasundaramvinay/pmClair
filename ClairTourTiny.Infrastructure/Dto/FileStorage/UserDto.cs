using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClairTourTiny.Infrastructure.Dto.FileStorage
{
    public class AvailableUserDto
    {
        [Column("Name")]
        public string? Name { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("id_Level")]
        public int? LevelId { get; set; }
    }

    public class MappedUserDto
    {
        [Column("Name")]
        public string? Name { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("id_Level")]
        public int? LevelId { get; set; }
        [Column("CloudFolderTemplate")]
        public string? CloudFolderTemplate { get; set; }

        [Column("isRemoveFolderMember")]
        public bool? isRemoveFolderMember { get; set; }

        [Column("isAddFolderMember")]
        public bool? isAddFolderMember { get; set; }
    }
}
