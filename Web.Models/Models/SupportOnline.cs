using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tu dong tang
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Deparment { get; set; }

        [MaxLength(256)]
        public string Skype { get; set; }

        [MaxLength(256)]
        public string Mobile { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string Yaho { get; set; }

        [MaxLength(256)]
        public string FaceBook { get; set; }

        public bool Status { get; set; }
    }
}