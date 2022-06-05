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

        public int StateId { get; set; } = 1;
        public string City { get; set; }
        public string Address { get; set; }

        public string ZipCode { get; set; }

        public IFormFile Image { get; set; }
        public string ProfileUrl { get; set; }
        public long? SubscriptionTypeId { get; set; }
        public int SubscriptionType { get; set; }


        public string BillingCountry { get; set; }
        public string BillingState { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }

        public DateTime? ConsultingDate { get; set; }



    }

    public class RevokeTokenRequest
    {
        public string Token { get; set; }
    }
    public class ChangePasswordModel
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class UpgradeSubscriptionModel
    {
        public long ? UserId { get; set; }
        public long? SubscriptionTypeId { get; set; }
        public int SubscriptionType { get; set; }
    }

    public class UpgradeBreakthroughSubscriptionModel
    {
        public long? UserId { get; set; }
        public long? SubscriptionTypeId { get; set; }
        public int SubscriptionType { get; set; }

        public string BillingCountry { get; set; }
        public string BillingState { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }
    }
}


