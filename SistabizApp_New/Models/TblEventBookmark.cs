using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblEventBookmark
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? EventId { get; set; }

        public virtual TblEvent Event { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
