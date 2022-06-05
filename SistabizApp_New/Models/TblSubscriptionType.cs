using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblSubscriptionType
    {
        public TblSubscriptionType()
        {
            TblBreakthrough = new HashSet<TblBreakthrough>();
            TblModulePermission = new HashSet<TblModulePermission>();
            TblUserSubscription = new HashSet<TblUserSubscription>();
        }

        public long SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public int? SubscriptionType { get; set; }
        public double? SubscriptionCost { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateOn { get; set; }

        public virtual ICollection<TblBreakthrough> TblBreakthrough { get; set; }
        public virtual ICollection<TblModulePermission> TblModulePermission { get; set; }
        public virtual ICollection<TblUserSubscription> TblUserSubscription { get; set; }
    }
}
