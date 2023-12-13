using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Models.Abstract;

namespace Web.Models.Models
{
    [Table("ProductCategoryes")]
    public class ProductCategorye : AudiTable
    {
        [Key] // Khoa chinh
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tu dong tang
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        //
        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
        // Noi khoa ngoai bang Product
        //public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}