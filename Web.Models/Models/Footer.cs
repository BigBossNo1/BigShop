using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key] // Khoa chinh
        [MaxLength(50)] // Gioi han ky tu
        public string ID { get; set; }

        [Required] // Bat buoc phai nhap
        public string Content { get; set; }
    }
}