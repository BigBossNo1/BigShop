using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Models
{
    [Table("VisitorStatics")]
    public class VisitorStatic
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime? VisitDate { get; set; }
        [MaxLength(50)]
        public string IPAddress { get; set; }
    }
}