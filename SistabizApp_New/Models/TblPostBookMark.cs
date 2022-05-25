using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblPostBookMark
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? PostId { get; set; }

        public virtual TblMember Member { get; set; }
        public virtual TblPost Post { get; set; }
    }
}
