using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMemberRoles
    {
        public TblMemberRoles()
        {
            TblMember = new HashSet<TblMember>();
        }

        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<TblMember> TblMember { get; set; }
    }
}
