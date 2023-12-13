using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order =1)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductyID { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ProductyID")]
        public virtual Product Products { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Orders { get; set; }
    }
}