using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblUserSubscription
    {
        public TblUserSubscription()
        {
            TblBillingAddress = new HashSet<TblBillingAddress>();
        }

        public long SubscriptionId { get; set; }
        public long? SubscriptionTypeId { get; set; }
        public long? Userid { get; set; }
        public int? SubscriptionDuration { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public string TransactionId { get; set; }
        public bool? IsPayment { get; set; }
        public int? PaymentStatus { get; set; }
        public bool? IsUpgrade { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateOn { get; set; }

        public virtual TblSubscriptionType SubscriptionType { get; set; }
        public virtual TblMember User { get; set; }
        public virtual ICollection<TblBillingAddress> TblBillingAddress { get; set; }
    }
}
