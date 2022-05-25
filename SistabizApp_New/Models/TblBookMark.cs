using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblBookMark
    {
        public long BookmarkId { get; set; }
        public long? BookmarkBy { get; set; }
        public long? BookmarkTo { get; set; }
        public DateTime? BookmarkDatet { get; set; }
        public int? Type { get; set; }

        public virtual TblMember BookmarkByNavigation { get; set; }
        public virtual TblMember BookmarkToNavigation { get; set; }
    }
}
