using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Models.Abstract;

namespace Web.Models.Models
{
    [Table("Products")]
    public class Product : AudiTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tu dong tang
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategorye ProductCategoryes { get; set; }

        public string Tags { get; set; } 

        public int Quantity { get; set; }

        // Noi voi khoa chinh bang ProductCategoryes
        //public virtual IEnumerable<ProductTag> ProductTags { get; set; }
        public virtual IEnumerable<ProductTag> ProductTag { get; set; }
    }
}