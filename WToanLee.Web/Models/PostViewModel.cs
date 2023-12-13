using System;
using System.Collections.Generic;

namespace WToanLee.Web.Models
{
    public class PostViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int CategoryID { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        //
        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }
        public bool Status { get; set; }
        public string MetaKeyWord { get; set; }

        public string MetaDesciption { get; set; }

        public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }

        public virtual PostcategoryViewModel PostCategories { get; set; }
    }
}