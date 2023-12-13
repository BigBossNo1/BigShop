using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order = 1)]
        public int PostID { get; set; }

        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar" , Order =2)]
        public string TagID { get; set; }

        [ForeignKey("PostID")]
        public virtual Post Posts { get; set; }

        [ForeignKey("TagID")]
        public virtual Tag Tags { get; set; }
    }
}