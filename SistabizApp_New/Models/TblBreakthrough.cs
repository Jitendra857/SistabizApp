using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblBreakthrough
    {
        public long BreakthroughId { get; set; }
        public long? SubscriptionType { get; set; }
        public long? MemberId { get; set; }
        public DateTime? ConsultingDate { get; set; }
        public int? Status { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsEmailSent { get; set; }

        public virtual TblMember Member { get; set; }
        public virtual TblSubscriptionType SubscriptionTypeNavigation { get; set; }
    }
}
