using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistabizApp.Authentication;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IBLLService memberService;



        public AuthenticateController(IBLLService member, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            memberService = member;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            MemberLoginResponseViewModel response = new MemberLoginResponseViewModel();
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)

                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                response = memberService.GetMemberByEmail(user.Email);
                response.UserId = user.Id;
                response.Token = new JwtSecurityTokenHandler().WriteToken(token);
                response.TokenExpiration = token.ValidTo;


                return Ok(new APIResponse(true, "Login Successfully.", "", response));
            }
            return Ok(new APIResponse(false, "Invalid username and password!", null, null));
            //return Unauthorized();
        }
        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> changePassword(ChangePasswordModel usermodel)
        {
            ApplicationUser user = await userManager.FindByIdAsync(usermodel.Id);
            if (user == null)
            {
                return NotFound();
            }
            //user.PasswordHash = userManager.PasswordHasher.HashPassword(usermodel.Password);
            var result = await userManager.ChangePasswordAsync(user, usermodel.OldPassword, usermodel.NewPassword);
            // var result1 = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return Ok(new APIResponse(false, "Incorrect Password!", null, "Incorrect Password!"));
                //throw exception......
            }
            var response = memberService.UpdateMemberPassword(user.Email, usermodel.NewPassword);
            return Ok(new APIResponse(true, "Password Changed Successfully.", "", ""));
        }

        [HttpGet]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var link = "http://localhost:58870/api/authenticate/resetpassword?";
                var buillink = link + "&Id=" + user.Id + "&token=" + token;

                var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                EmailHelper emailHelper = new EmailHelper();
                bool emailResponse = emailHelper.SendEmail(user.Email, buillink);


                //var emailtemplate = new EmailTemplate();
                //emailtemplate.Link = buillink;
                //emailtemplate.UserId = user.Id;
                //emailtemplate.EmailType = EmailType.ResetPassword;
                //var emailsent = _emailService.SendSmtpMail(emailtemplate);
                if (emailResponse != true)
                    return Ok(new APIResponse(false, "Email not sent.", "", System.Net.HttpStatusCode.InternalServerError));

                return Ok(new APIResponse(true, "Link Sent Succesfully.", System.Net.HttpStatusCode.OK.ToString(), buillink));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        [Route("resetpassword")]
        public async Task<IActionResult> ConfirmPwdLink(Guid id, string token, string newpassword)
        {
            //newpassword = "Jeet@12345";

            string uid = id.ToString();
            ApplicationUser user = await userManager.FindByIdAsync(uid);



            //  var user = await userManager.FindByIdAsync(id);
            var result = await userManager.ResetPasswordAsync(user, token, newpassword);
            if (!result.Succeeded)
            {
                return Ok(new APIResponse(false, "Invalid Request.", "", System.Net.HttpStatusCode.UnprocessableEntity.ToString()));

            }
            else
            {
                return Ok(new APIResponse(true, "Your Password has been succesfully updated.", "", System.Net.HttpStatusCode.OK.ToString()));

            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {


            // var CurrentRequestOfHttp = HttpContext.Current.Request;
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            if (model.Image != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Profiles", model.Image.FileName); ;
                if (model.Image.Length > 0)
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {

                        model.Image.CopyTo(fileStream);
                    }
                }
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfileName = model.Image!=null? model.Image.FileName:""

            };
            TblMember member = new TblMember()
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfileImage = model.Image != null ? model.Image.FileName : "",
                Mobile = model.Mobile,
                StateId = model.StateId,
                City = model.City,
                Address = model.Address,
                ZipCode = model.ZipCode,
                CreatedOn = DateTime.Now,
                IsActive = model.SubscriptionTypeId == 3 ? false : true,
                IsDelete = false,
                RoleId = Role.Member,


            };


            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var data = memberService.AddEmployee(member);
                if (data != null)
                {
                    TblUserSubscription subscription = new TblUserSubscription()
                    {
                        SubscriptionTypeId = model.SubscriptionTypeId,
                        Userid = data.MemberId,
                        TransactionId = Guid.NewGuid().ToString(),
                        SubscriptionStartDate = DateTime.Now,
                        SubscriptionEndDate = model.SubscriptionType == 1 ? DateTime.Now.AddMonths(1) : DateTime.Now.AddMonths(12),
                        SubscriptionDuration = model.SubscriptionType,
                        PaymentStatus = 1,
                        IsPayment = model.SubscriptionTypeId == 3 ? false : true,
                        IsUpgrade = false,
                        IsActive = model.SubscriptionTypeId == 3 ? false : true,
                        IsDeleted = false,
                        CreateOn = DateTime.Now,
                    };
                    var usersubscription = memberService.AddSubscription(subscription);

                    if (usersubscription != null)
                    {
                        if (model.SubscriptionTypeId != 3)
                        {
                            TblBillingAddress billingaddress = new TblBillingAddress();
                            billingaddress.Country = model.BillingCountry;
                            billingaddress.State = model.BillingState;
                            billingaddress.City = model.BillingCity;
                            billingaddress.Address = model.BillingAddress;
                            billingaddress.ZipCode = model.BillingZipCode;
                            billingaddress.PaymentId = usersubscription.SubscriptionId;

                            var billingaddressresult = memberService.AddBillingAddress(billingaddress);
                        }
                        else
                        {
                            TblBreakthrough breakthrough = new TblBreakthrough();
                            breakthrough.ConsultingDate = model.ConsultingDate;
                            breakthrough.MemberId = data.MemberId;
                            breakthrough.Status = 1;
                            breakthrough.SubscriptionType = model.SubscriptionType;
                            breakthrough.CreatedOn = DateTime.Now;
                            breakthrough.IsDeleted = false;

                            var breakthroughresult = memberService.ManageBreakThrough(breakthrough);

                        }
                    }

                }

                return Ok(new APIResponse(true, Constant.Success, "", "User created successfully!"));
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                EmailHelper emailHelper = new EmailHelper();
                bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

                if (emailResponse)
                    return Ok(new APIResponse(true, Constant.Success, "", "User created successfully!"));
                else
                {
                    // log email failed 
                }

            }
            else
            {
                var errormessage = result.Errors.FirstOrDefault();//[0].de.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = errormessage.Description });
            }
        }

        [HttpPost("upgradesubscription")]
        public IActionResult UpgradeSubscription(UpgradeSubscriptionModel model)
        {
            if (model.UserId > 0)
            {
                memberService.CancelSubscription((int)model.UserId);
            }
            TblUserSubscription subscription = new TblUserSubscription()
            {
                SubscriptionTypeId = model.SubscriptionTypeId,
                Userid = model.UserId,
                TransactionId = Guid.NewGuid().ToString(),
                SubscriptionStartDate = DateTime.Now,
                SubscriptionEndDate = model.SubscriptionType == 1 ? DateTime.Now.AddMonths(1) : DateTime.Now.AddMonths(12),
                SubscriptionDuration = model.SubscriptionType,
                PaymentStatus = 1,
                IsPayment = true,
                IsUpgrade = true,
                IsActive = true,
                IsDeleted = false,
                CreateOn = DateTime.Now,
            };
            var usersubscription = memberService.AddSubscription(subscription);


            return Ok(new APIResponse(true, Constant.Success, "", "User subscription upgrade successfully!"));
        }


        [HttpPost("upgradebreakthroughsubscription")]
        public IActionResult UpgradeBreathroughSubscription(UpgradeBreakthroughSubscriptionModel model)
        {
            TblUserSubscription subscription = new TblUserSubscription();
            if (model.UserId > 0)
            {
                memberService.GetSubscriptionSubscription((int)model.UserId);
            }


            subscription.SubscriptionTypeId = model.SubscriptionTypeId;
            subscription.Userid = model.UserId;
            subscription.TransactionId = Guid.NewGuid().ToString();
            //subscription.SubscriptionStartDate = DateTime.Now;
            //subscription.SubscriptionEndDate = model.SubscriptionType == 1 ? DateTime.Now.AddMonths(1) : DateTime.Now.AddMonths(12);
            subscription.SubscriptionDuration = model.SubscriptionType;
            subscription.PaymentStatus = 1;
            subscription.IsPayment = true;
            subscription.IsUpgrade = true;
            subscription.IsActive = true;
            subscription.IsDeleted = false;
            subscription.CreateOn = DateTime.Now;

            var usersubscription = memberService.AddSubscription(subscription);

            TblBillingAddress billingaddress = new TblBillingAddress();
            billingaddress.Country = model.BillingCountry;
            billingaddress.State = model.BillingState;
            billingaddress.City = model.BillingCity;
            billingaddress.Address = model.BillingAddress;
            billingaddress.ZipCode = model.BillingZipCode;
            billingaddress.PaymentId = usersubscription.SubscriptionId;

            var billingaddressresult = memberService.AddBillingAddress(billingaddress);

            return Ok(new APIResponse(true, Constant.Success, "", "User breakthrough subscription successfully!"));
        }



        [HttpPost]
        [Route("updateprofile")]
        public async Task<IActionResult> UpdateProfile([FromForm] RegisterModel model)
        {


            // var CurrentRequestOfHttp = HttpContext.Current.Request;
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Profiles", model.Image.FileName); ;
            if (model.Image.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    model.Image.CopyTo(fileStream);
                }
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfileName = model.Image.FileName

            };
            TblMember member = new TblMember()
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfileImage = model.Image.FileName,
                Mobile = model.Mobile,
                StateId = model.StateId,
                City = model.City,
                Address = model.Address,
                ZipCode = model.ZipCode,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDelete = false,


            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                memberService.AddEmployee(member);
                return Ok(new APIResponse(true, Constant.Success, "", "User created successfully!"));
                //var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                //var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                //EmailHelper emailHelper = new EmailHelper();
                //bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

                //if (emailResponse)
                //    return Ok(new APIResponse(true, Constant.Success, "", "User created successfully!"));
                //else
                //{
                //    // log email failed 
                //}

            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
        }


        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}