using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WToanLee.Web.Models
{
    public class ProductTagViewModel
    {
        public int ProductID { get; set; }

        public string TagID { get; set; }


        public virtual ProductViewModel Products { get; set; }

        public virtual TagViewModel Tags { get; set; }
    }
}