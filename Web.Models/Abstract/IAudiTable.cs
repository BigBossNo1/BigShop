using System;

namespace Web.Models.Abstract
{
    public interface IAudiTable
    {
        DateTime? CreateDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateBy { get; set; }

        bool Status { get; set; }

        string MetaKeyWord { get; set; }
        string MetaDesciption { get; set; }
    }
}