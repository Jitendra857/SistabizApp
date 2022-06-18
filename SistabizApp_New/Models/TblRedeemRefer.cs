using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblRedeemRefer
    {
        public long Id { get; set; }
        public long? RedeemId { get; set; }
        public long? ReferBy { get; set; }
        public long? ReferTo { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual TblReddemPoints Redeem { get; set; }
    }
}
