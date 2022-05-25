using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblDigitalLibraryCategory
    {
        public TblDigitalLibraryCategory()
        {
            TblDigitalLibrary = new HashSet<TblDigitalLibrary>();
            TblDigitalLibraryBookmark = new HashSet<TblDigitalLibraryBookmark>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TblDigitalLibrary> TblDigitalLibrary { get; set; }
        public virtual ICollection<TblDigitalLibraryBookmark> TblDigitalLibraryBookmark { get; set; }
    }
}
