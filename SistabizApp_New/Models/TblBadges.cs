using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblBadges
    {
        public TblBadges()
        {
            TblBadgesAssignMember = new HashSet<TblBadgesAssignMember>();
        }

        public long BadgesId { get; set; }
        public string BadgesName { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<TblBadgesAssignMember> TblBadgesAssignMember { get; set; }
    }
}
