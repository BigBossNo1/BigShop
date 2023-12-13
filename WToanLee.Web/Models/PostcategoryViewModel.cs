using System;
using System.Collections.Generic;

namespace WToanLee.Web.Models
{
    public  class PostcategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

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
        public bool Status { get; set; }
        public string MetaKeyWord { get; set; }

        public string MetaDesciption { get; set; }

        public virtual IEnumerable<PostViewModel> Posts { get; set; }
    }
}