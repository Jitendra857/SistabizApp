using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroup
    {
        public TblGroup()
        {
            TblGroupAttachment = new HashSet<TblGroupAttachment>();
            TblGroupJoinMember = new HashSet<TblGroupJoinMember>();
        }

        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual ICollection<TblGroupAttachment> TblGroupAttachment { get; set; }
        public virtual ICollection<TblGroupJoinMember> TblGroupJoinMember { get; set; }
    }
}
