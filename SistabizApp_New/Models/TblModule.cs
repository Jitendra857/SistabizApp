using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblModule
    {
        public TblModule()
        {
            TblModulePermission = new HashSet<TblModulePermission>();
        }

        public long ModuleId { get; set; }
        public string ModuleName { get; set; }
        public DateTime? CreateOn { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual ICollection<TblModulePermission> TblModulePermission { get; set; }
    }
}
