using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WToanLee.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { set; get; }
        public IEnumerable<ProductViewModel> lastestProduct { set; get; }
        public IEnumerable<ProductViewModel> topSaleProduct { set; get; }
    }
}