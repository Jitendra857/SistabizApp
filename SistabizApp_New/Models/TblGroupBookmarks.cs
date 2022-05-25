using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroupBookmarks
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? CategoryId { get; set; }
        public long? GroupId { get; set; }

        public virtual TblGroupCategory Category { get; set; }
        public virtual TblGroup Group { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
