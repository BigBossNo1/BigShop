using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WToanLee.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }

        public string Image { get; set; }

        public int? DisplayOrder { get; set; }

        //
        public bool? HomeFlag { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        [Required]
        public bool Status { get; set; }
        public string MetaKeyWord { get; set; }

        public string MetaDesciption { get; set; }

        public virtual IEnumerable<ProductViewModel> Product { get; set; }
    }
}