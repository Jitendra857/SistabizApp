using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp.Authentication
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string ProfileName { get; set; }
        public string LastName { get; set; }
    }
}
