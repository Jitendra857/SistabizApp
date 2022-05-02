using SistabizApp.Authentication;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService : IBLLService
    {

        public List<MemberViewModel> MemberList()
        {
            var employee = _entityDbContext.TblMember.Select(e => new MemberViewModel
            {

                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = e.ProfileImage,
                Mobile = e.Mobile,
                StateId = (int)e.StateId,
                City = e.City,
                Address = e.Address,
                ZipCode = e.ZipCode,
                AboutMe = e.AboutMe,
                BusinessName = e.BusinessName,
                WebsiteUrl = e.WebsiteUrl,
                AboutBusiness = e.AboutBusiness,
                BusinessType = e.BusinessType,
                Industry = e.Industry,
                CustomerType = e.CustomerType,
                YearsInBusiness = e.YearsInBusiness,
                Employess = e.Employess,
                GovernmentCertifications = e.GovernmentCertifications,
                EntityType = e.EntityType,
                BusinessState = e.BusinessState,
                SocialMedia = e.SocialMedia,
                GrowthGoals = e.GrowthGoals,
                BusinessGoals = e.BusinessGoals,
                CreatedOn = e.CreatedOn
            }).ToList();
            return employee;
        
        }

        public TblMember AddEmployee(TblMember employee)
        {
            if (employee != null)
            {
                _entityDbContext.TblMember.Add(employee);
                _entityDbContext.SaveChanges();
                return employee;
            }
            return null;
        }

        public string RemoverMember(int memberid)
        {
            var member = _entityDbContext.TblMember.Where(e => e.MemberId == memberid).FirstOrDefault();
            if (member != null)
            {
                _entityDbContext.TblMember.Remove(member);
                _entityDbContext.SaveChanges();
            }
            return "Success";

        }
                  

        public MemberViewModel GetEmployeeById(int memberid)
        {
            var employee = _entityDbContext.TblMember.Where(x => x.MemberId == memberid).Select(e => new MemberViewModel
            {

                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = e.ProfileImage,
                Mobile = e.Mobile,
                StateId = (int)e.StateId,
                City = e.City,
                Address = e.Address,
                ZipCode = e.ZipCode,
                AboutMe = e.AboutMe,
                BusinessName = e.BusinessName,
                WebsiteUrl = e.WebsiteUrl,
                AboutBusiness = e.AboutBusiness,
                BusinessType = e.BusinessType,
                Industry = e.Industry,
                CustomerType = e.CustomerType,
                YearsInBusiness = e.YearsInBusiness,
                Employess = e.Employess,
                GovernmentCertifications = e.GovernmentCertifications,
                EntityType = e.EntityType,
                BusinessState = e.BusinessState,
                SocialMedia = e.SocialMedia,
                GrowthGoals = e.GrowthGoals,
                BusinessGoals = e.BusinessGoals,
                CreatedOn = e.CreatedOn
            }).FirstOrDefault();
            return employee;
        }

        public MemberViewModel Updateprofile(MemberViewModel model)
        {
            var getMemberById = _entityDbContext.TblMember.Where(e => e.MemberId == model.MemberId).FirstOrDefault();
            if (getMemberById != null)
            {
                getMemberById.FirstName = model.FirstName;
                getMemberById.LastName = model.LastName;
                getMemberById.NickName = model.NickName;
                getMemberById.ProfileImage = model.ProfileImage;
                getMemberById.Mobile = model.Mobile;
                getMemberById.StateId = (int)model.StateId;
                getMemberById.City = model.City;
                getMemberById.Address = model.Address;
                getMemberById.ZipCode = model.ZipCode;
                getMemberById.AboutMe = model.AboutMe;
                getMemberById.BusinessName = model.BusinessName;
                getMemberById.WebsiteUrl = model.WebsiteUrl;
                getMemberById.AboutBusiness = model.AboutBusiness;
                getMemberById.BusinessType = model.BusinessType;
                getMemberById.Industry = model.Industry;
                getMemberById.CustomerType = model.CustomerType;
                getMemberById.YearsInBusiness = model.YearsInBusiness;
                getMemberById.Employess = model.Employess;
                getMemberById.GovernmentCertifications = model.GovernmentCertifications;
                getMemberById.EntityType = model.EntityType;
                getMemberById.BusinessState = model.BusinessState;
                getMemberById.SocialMedia = model.SocialMedia;
                getMemberById.GrowthGoals = model.GrowthGoals;
                getMemberById.BusinessGoals = model.BusinessGoals;

                _entityDbContext.SaveChanges();
            }

            return model;
        }

        public MemberLoginResponseViewModel GetMemberByEmail(string email)
        {

            var employee = _entityDbContext.TblMember.Where(x => x.Email == email).Select(e => new MemberLoginResponseViewModel
            {

                Email = e.Email,
               
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = e.ProfileImage,
                Mobile = e.Mobile,
               
                City = e.City,
                Address = e.Address,
                ZipCode = e.ZipCode,
                AboutMe = e.AboutMe,
                BusinessName = e.BusinessName,
                WebsiteUrl = e.WebsiteUrl,
                AboutBusiness = e.AboutBusiness,
                BusinessType = e.BusinessType,
                Industry = e.Industry,
                CustomerType = e.CustomerType,
                YearsInBusiness = e.YearsInBusiness,
                Employess = e.Employess,
                GovernmentCertifications = e.GovernmentCertifications,
                EntityType = e.EntityType,
                BusinessState = e.BusinessState,
                SocialMedia = e.SocialMedia,
                GrowthGoals = e.GrowthGoals,
                BusinessGoals = e.BusinessGoals,
                CreatedOn = e.CreatedOn
            }).FirstOrDefault();
            return employee;
        }
        
    }
}
