using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMember
    {
        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
    }
}
