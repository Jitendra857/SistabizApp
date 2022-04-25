using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMember
    {
        public TblMember()
        {
            TblEvent = new HashSet<TblEvent>();
            TblEventRegisterMember = new HashSet<TblEventRegisterMember>();
            TblServiceRequest = new HashSet<TblServiceRequest>();
        }

        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public long? StateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ProfileImage { get; set; }
        public string AboutMe { get; set; }
        public string BusinessName { get; set; }
        public string WebsiteUrl { get; set; }
        public string AboutBusiness { get; set; }
        public int? BusinessType { get; set; }
        public string Industry { get; set; }
        public int? CustomerType { get; set; }
        public int? YearsInBusiness { get; set; }
        public int? Employess { get; set; }
        public string GovernmentCertifications { get; set; }
        public int? EntityType { get; set; }
        public string BusinessState { get; set; }
        public string SocialMedia { get; set; }
        public string GrowthGoals { get; set; }
        public string BusinessGoals { get; set; }

        public virtual ICollection<TblEvent> TblEvent { get; set; }
        public virtual ICollection<TblEventRegisterMember> TblEventRegisterMember { get; set; }
        public virtual ICollection<TblServiceRequest> TblServiceRequest { get; set; }
    }
}
