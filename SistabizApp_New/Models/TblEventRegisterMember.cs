using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblEventRegisterMember
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public long? RegisterMemberId { get; set; }
        public int? Status { get; set; }

        public virtual TblEvent Event { get; set; }
        public virtual TblMember RegisterMember { get; set; }
    }
}
