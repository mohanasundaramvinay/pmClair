using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClairTourTiny.Infrastructure.Dto.FileStorage
{
    public class CloudFolderTemplateDto
    {
        [Column("CloudFolderTemplate")]
        public string CloudFolderTemplate { get; set; } = string.Empty;

        [Column("id_Level")]
        public int id_Level { get; set; }
    }

    public class CloudFolderTemplateResultDto
    {
        [Column("CloudFolderTemplate")]
        public string CloudFolderTemplate { get; set; } = string.Empty;
    }
}
