using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }

        public int StateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public string ZipCode { get; set; }
       
        public IFormFile Image { get; set; }
        public string ProfileUrl { get; set; }
    }
    public class RevokeTokenRequest
    {
        public string Token { get; set; }
    }
}
