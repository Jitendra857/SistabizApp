using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblReddemPoints
    {
        public long ReddemId { get; set; }
        public long? MemberId { get; set; }
        public int? ReddemPoint { get; set; }
        public long? ReddemBy { get; set; }
        public long? ReferTo { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }
        public DateTime? CreateOn { get; set; }

        public virtual TblMember Member { get; set; }
        public virtual TblMember ReddemByNavigation { get; set; }
        public virtual TblMember ReferToNavigation { get; set; }
    }
}
