using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroup
    {
        public TblGroup()
        {
            TblGroupAttachment = new HashSet<TblGroupAttachment>();
            TblGroupBookmarks = new HashSet<TblGroupBookmarks>();
            TblGroupDiscussion = new HashSet<TblGroupDiscussion>();
            TblGroupJoinMember = new HashSet<TblGroupJoinMember>();
            TblGroupMeeting = new HashSet<TblGroupMeeting>();
        }

        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
        public long? Category { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string GroupIcon { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblGroupCategory CategoryNavigation { get; set; }
        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual ICollection<TblGroupAttachment> TblGroupAttachment { get; set; }
        public virtual ICollection<TblGroupBookmarks> TblGroupBookmarks { get; set; }
        public virtual ICollection<TblGroupDiscussion> TblGroupDiscussion { get; set; }
        public virtual ICollection<TblGroupJoinMember> TblGroupJoinMember { get; set; }
        public virtual ICollection<TblGroupMeeting> TblGroupMeeting { get; set; }
    }
}
