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
       


        public AuthenticateController(IBLLService member,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
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
                response.Token = new JwtSecurityTokenHandler().WriteToken(token);
                response.TokenExpiration= token.ValidTo;

                //return Ok(new
                //{
                //    token = new JwtSecurityTokenHandler().WriteToken(token),
                //    expiration = token.ValidTo


                //});

                return Ok(new APIResponse(true, Constant.Success, "", response));
            }
            return Unauthorized();
        }
    
       

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
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
                FirstName=model.FirstName,
                LastName = model.LastName,
                ProfileName= model.Image.FileName

            };
            TblMember member = new TblMember()
            {
                Email = model.Email,
                Password=model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfileImage = model.Image.FileName,
                Mobile=model.Mobile,
                StateId=model.StateId,
                City=model.City,
                Address=model.Address,
                ZipCode=model.ZipCode,
                CreatedOn=DateTime.Now,
                IsActive=true,
                IsDelete=false,


            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                memberService.AddEmployee(member);
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
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
        }
       
        //[HttpPost("revoke-token")]
        //public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
        //{
        //    // accept token from request body or cookie
        //    var token = model.Token ?? Request.Cookies["refreshToken"];

        //    if (string.IsNullOrEmpty(token))
        //        return BadRequest(new { message = "Token is required" });

        //    var response = _userService.RevokeToken(token, ipAddress());

        //    if (!response)
        //        return NotFound(new { message = "Token not found" });

        //    return Ok(new { message = "Token revoked" });
        //}

       

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