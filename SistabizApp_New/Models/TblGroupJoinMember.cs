using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroupJoinMember
    {
        public long JoinId { get; set; }
        public long? GroupId { get; set; }
        public long? JoinMemberId { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblGroup Group { get; set; }
        public virtual TblMember JoinMember { get; set; }
    }
}
