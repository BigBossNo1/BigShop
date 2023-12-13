using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Models.Abstract;

namespace Web.Models.Models
{
    [Table("PostCategories")]
    public class PostCategorie : AudiTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tu dong tang
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int? ParentID { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        public int? DisplayOrder { get; set; }

        //
        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}