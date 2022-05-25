using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMemberDesignation
    {
        public long DesignationId { get; set; }
        public string Designation { get; set; }
        public long? MemberId { get; set; }

        public virtual TblMember Member { get; set; }
    }
}
