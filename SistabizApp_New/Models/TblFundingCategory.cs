using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblFundingCategory
    {
        public TblFundingCategory()
        {
            TblFundingBookmark = new HashSet<TblFundingBookmark>();
            TblFundingResources = new HashSet<TblFundingResources>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TblFundingBookmark> TblFundingBookmark { get; set; }
        public virtual ICollection<TblFundingResources> TblFundingResources { get; set; }
    }
}
