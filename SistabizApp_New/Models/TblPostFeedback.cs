using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblPostFeedback
    {
        public long PostFeedId { get; set; }
        public int? LikeUnlike { get; set; }
        public string Commets { get; set; }
        public long? MemberId { get; set; }
        public long? PostId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateOn { get; set; }

        public virtual TblMember Member { get; set; }
        public virtual TblPost Post { get; set; }
    }
}
