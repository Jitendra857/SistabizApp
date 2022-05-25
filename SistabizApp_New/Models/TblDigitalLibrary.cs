using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblDigitalLibrary
    {
        public TblDigitalLibrary()
        {
            TblDigitalLibaryAttachment = new HashSet<TblDigitalLibaryAttachment>();
            TblDigitalLibraryBookmark = new HashSet<TblDigitalLibraryBookmark>();
        }

        public long DigitalLibraryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
        public double? Price { get; set; }
        public long? CategoryId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string ProfileIcon { get; set; }

        public virtual TblDigitalLibraryCategory Category { get; set; }
        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual ICollection<TblDigitalLibaryAttachment> TblDigitalLibaryAttachment { get; set; }
        public virtual ICollection<TblDigitalLibraryBookmark> TblDigitalLibraryBookmark { get; set; }
    }
}
