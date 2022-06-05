using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMemberMatches
    {
        public long MatchesId { get; set; }
        public long? MemberId { get; set; }
        public long? MatchesMemberid { get; set; }
        public int? Type { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual TblMember MatchesMember { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
