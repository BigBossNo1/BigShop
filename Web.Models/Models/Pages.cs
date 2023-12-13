using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Models
{
    [Table("Pages")]
    public class Pages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tu dong tang
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        [Required]
        public string Alias { get; set; }
        public string Content { get; set; }


    }
}