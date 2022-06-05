using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class UserSubscriptionViewModel
    {
    }
    public class BreathroughModel
    {
        public long BreakthroughId { get; set; }
        public long? SubscriptionType { get; set; }
        public string SubscriptionName { get; set; }
        public long? MemberId { get; set; }
        public string MemberName { get; set; }
        public bool? IsEmailSent { get; set; }
        public DateTime? ConsultingDate { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }
    }

    public class BreakthroughRequest
    {
        public long? Id { get; set; }
        public long? MemberId { get; set; }
        public string RequestLink { get; set; }
    }
}
