using System.Collections.Generic;
using System.Linq;

namespace WToanLee.Web.Infrastructure.Core
{
    public class PagenationSet<T>
    {
        // trang
        public int Page { get; set; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        // tong so trang
        public int TotalPage { get; set; }

        // tong so ban ghi /1 trang
        public int TotalCount { get; set; }

        // max cua page
        public int MaxPage { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}