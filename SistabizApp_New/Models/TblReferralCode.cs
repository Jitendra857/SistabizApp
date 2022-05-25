using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblReferralCode
    {
        public long ReferralId { get; set; }
        public string ReferralCode { get; set; }
        public long? MemberId { get; set; }
    }
}
