using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Models
{
    [Table("Slides")]
    public class Slide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tu dong tang
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Descripts { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [MaxLength(256)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public bool Status { get; set; }

        public string Content { get; set; }
    }
}