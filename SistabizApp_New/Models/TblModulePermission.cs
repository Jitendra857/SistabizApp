using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblModulePermission
    {
        public long PermissionId { get; set; }
        public long? ModuleId { get; set; }
        public long? SubscriptionType { get; set; }
        public int? MemberRole { get; set; }

        public virtual TblModule Module { get; set; }
        public virtual TblSubscriptionType SubscriptionTypeNavigation { get; set; }
    }
}
