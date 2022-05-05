using SistabizApp.Authentication;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService : IBLLService
    {

        public List<MemberViewModel> MemberList(string search=null)
        {
            List<TblMember> memberlist = new List<TblMember>();
            if (!string.IsNullOrEmpty(search))
                memberlist = _entityDbContext.TblMember.Where(r => r.FirstName.Contains(search) || r.LastName.Contains(search) || r.Mobile.Contains(search) || r.Email.Contains(search) || r.Mobile.Contains(search)).ToList();
            else
                memberlist = _entityDbContext.TblMember.ToList();
            
            var employee = memberlist.Select(e => new MemberViewModel
            {
                MemberId=e.MemberId,
                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = Constant.livebaseurl+ "images/"+ e.ProfileImage,
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
            return employee;
        }

        public TblUserSubscription AddSubscription(TblUserSubscription subscription)
        {
            if (subscription != null)
            {
                _entityDbContext.TblUserSubscription.Add(subscription);
                _entityDbContext.SaveChanges();
                return subscription;
            }
            return subscription;
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
                MemberId=e.MemberId,
                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = Constant.livebaseurl + "images/" + e.ProfileImage,
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
                MemberId=e.MemberId,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = Constant.livebaseurl + "images/" + e.ProfileImage,
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
