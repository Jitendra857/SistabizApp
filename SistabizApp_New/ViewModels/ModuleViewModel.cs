using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class ModuleViewModel
    {
        public long ModuleId { get; set; }
        public string ModuleName { get; set; }
        public DateTime? CreateOn { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }

    public class SubscriptionViewModel
    {
        public long SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
       
    }

    public class ModulePermissionViewModel
    {
        public long PermissionId { get; set; }
        public long? ModuleId { get; set; }
        public long? SubscriptionType { get; set; }
    }
}
