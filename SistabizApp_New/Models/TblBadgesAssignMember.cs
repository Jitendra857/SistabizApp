using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblBadgesAssignMember
    {
        public long BadgesAssignId { get; set; }
        public long? BadgesId { get; set; }
        public long? MemberId { get; set; }
        public DateTime? AssginDate { get; set; }

        public virtual TblBadges Badges { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
