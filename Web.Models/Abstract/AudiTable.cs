using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Abstract
{
    public abstract class AudiTable : IAudiTable
    {
        public DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [MaxLength(256)]
        public string UpdateBy { get; set; }
        [Required]
        public bool Status { get; set; }
        [MaxLength(256)]
        public string MetaKeyWord { get; set; }

        [MaxLength(256)]
        public string MetaDesciption { get; set; }
    }
}