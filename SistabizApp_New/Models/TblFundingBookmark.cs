using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblFundingBookmark
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? FundingId { get; set; }
        public long? CategoryId { get; set; }

        public virtual TblFundingCategory Category { get; set; }
        public virtual TblFundingResources Funding { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
