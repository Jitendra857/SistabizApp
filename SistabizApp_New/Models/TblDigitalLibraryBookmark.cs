using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblDigitalLibraryBookmark
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? DigitalLibrryId { get; set; }
        public long? CategoryId { get; set; }

        public virtual TblDigitalLibraryCategory Category { get; set; }
        public virtual TblDigitalLibrary DigitalLibrry { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
