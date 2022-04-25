using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblFaqCategory
    {
        public TblFaqCategory()
        {
            TblFaq = new HashSet<TblFaq>();
        }

        public long FaqCategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TblFaq> TblFaq { get; set; }
    }
}
