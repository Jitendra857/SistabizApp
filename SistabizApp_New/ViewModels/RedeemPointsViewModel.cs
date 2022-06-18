using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{

    public class RedeemPointsDetailsViewModel
    {
        public long ReddemId { get; set; }
        public long? MemberId { get; set; }
        public string RedeemByName { get; set; }
        public int? ReddemPoint { get; set; }
        public int? TotalEarnPoint { get; set; }
        public long? ReddemBy { get; set; }
        public string RedeemToName { get; set; }
        public long? ReferTo { get; set; }
        public string RedeemReferName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateOn { get; set; }
        public int? Status { get; set; } = 0;
        public bool IsAccept { get; set; } = false;
    }
    public class MemberErnsPointModel
    {
        public int? TotalEarnsPoint { get; set; }
        public List<RedeemPointsDetailsViewModel> lstEarnsPoint { get; set; } = new List<RedeemPointsDetailsViewModel>();
    }
    public class RedeemPointsViewModel
    {
        public long ReddemId { get; set; }
        public long? MemberId { get; set; }
        public int? ReddemPoint { get; set; }
        public long? ReddemBy { get; set; }
        public long? ReferTo { get; set; }
        public string Description { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool IsAccept { get; set; } = false;
    }

    public class AcceptReferRedeemViewModel
    {
        public long ReddemId { get; set; }
        public long? MemberId { get; set; }
        public int? ReddemPoint { get; set; }
        public long? ReddemBy { get; set; }
        public long? ReferTo { get; set; }
        public string Description { get; set; }
        public DateTime? CreateOn { get; set; }
    }

    public class RedeemReferViewModel
    {
        public long ReddemId { get; set; }
        public long? ReferBy { get; set; }
        public int? ReferTo { get; set; }
        public DateTime? CreateOn { get; set; }
    }


}
