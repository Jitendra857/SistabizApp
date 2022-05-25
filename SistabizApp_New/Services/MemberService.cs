using Microsoft.EntityFrameworkCore;
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

        public List<MemberViewModel> MemberList(string search = null)
        {
            List<TblMember> memberlist = new List<TblMember>();
            if (!string.IsNullOrEmpty(search))
            {
                memberlist = _entityDbContext.TblMember.Where(r => r.IsDelete!=true &&(r.FirstName.Contains(search) || r.LastName.Contains(search) || r.Mobile.Contains(search) || r.Email.Contains(search) || r.Mobile.Contains(search)))

                         .Include(s => s.Role)
                         .Include(s => s.TblBookMarkBookmarkByNavigation)
                         .ToList();
            }
            else
            {
                memberlist = _entityDbContext.TblMember.Where(r => r.IsDelete != true)

                        .Include(s => s.Role)
                        .Include(s => s.TblBookMarkBookmarkByNavigation)
                        .ToList();
            }

            return memberlist.Select(e => new MemberViewModel
            {
                MemberId = e.MemberId,
                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
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
                CreatedOn = e.CreatedOn,
                ProfilePercentage = 25,// getprfilePercentage(e),
                RoleId = e.RoleId,
                RoleName = e.Role != null ? e.Role.RoleName : null,
                RoleIcon = e.RoleId ==1 ? Constant.MemberIcon : Constant.MemberIcon,
                IsBookmark = e.TblBookMarkBookmarkByNavigation.Count > 0 ? true : e.TblBookMarkBookmarkToNavigation.Count > 0 ? true : false
            }).ToList();


            //if (!string.IsNullOrEmpty(search))
            //{
            //   return _entityDbContext.TblMember.Where(r => r.FirstName.Contains(search) || r.LastName.Contains(search) || r.Mobile.Contains(search) || r.Email.Contains(search) || r.Mobile.Contains(search)).Select(e => new MemberViewModel
            //    {
            //        MemberId = e.MemberId,
            //        Email = e.Email,
            //        Password = e.Password,
            //        FirstName = e.FirstName,
            //        LastName = e.LastName,
            //        ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
            //        Mobile = e.Mobile,
            //        StateId = (int)e.StateId,
            //        City = e.City,
            //        Address = e.Address,
            //        ZipCode = e.ZipCode,
            //        AboutMe = e.AboutMe,
            //        BusinessName = e.BusinessName,
            //        WebsiteUrl = e.WebsiteUrl,
            //        AboutBusiness = e.AboutBusiness,
            //        BusinessType = e.BusinessType,
            //        Industry = e.Industry,
            //        CustomerType = e.CustomerType,
            //        YearsInBusiness = e.YearsInBusiness,
            //        Employess = e.Employess,
            //        GovernmentCertifications = e.GovernmentCertifications,
            //        EntityType = e.EntityType,
            //        BusinessState = e.BusinessState,
            //        SocialMedia = e.SocialMedia,
            //        GrowthGoals = e.GrowthGoals,
            //        BusinessGoals = e.BusinessGoals,
            //        CreatedOn = e.CreatedOn,
            //       ProfilePercentage = 25,// getprfilePercentage(e),
            //       RoleId = e.RoleId,
            //        RoleName = e.Role != null ? e.Role.RoleName : null,
            //        IsBookmark=e.TblBookMarkBookmarkByNavigation!=null?true:false
            //    }).ToList();
            //}
            //else
            //{
            //    var memberlist = _entityDbContext.TblMember.ToList();

            //    var studentWithGrade = _entityDbContext.TblMember

            //               .Include(s => s.Role)
            //               .Include(s=>s.TblBookMarkBookmarkByNavigation)
            //               .ToList();

            //    return _entityDbContext.TblMember.Select(e => new MemberViewModel
            //    {
            //        MemberId = e.MemberId,
            //        Email = e.Email,
            //        Password = e.Password,
            //        FirstName = e.FirstName,
            //        LastName = e.LastName,
            //        ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
            //        Mobile = e.Mobile,
            //        StateId = (int)e.StateId,
            //        City = e.City,
            //        Address = e.Address,
            //        ZipCode = e.ZipCode,
            //        AboutMe = e.AboutMe,
            //        BusinessName = e.BusinessName,
            //        WebsiteUrl = e.WebsiteUrl,
            //        AboutBusiness = e.AboutBusiness,
            //        BusinessType = e.BusinessType,
            //        Industry = e.Industry,
            //        CustomerType = e.CustomerType,
            //        YearsInBusiness = e.YearsInBusiness,
            //        Employess = e.Employess,
            //        GovernmentCertifications = e.GovernmentCertifications,
            //        EntityType = e.EntityType,
            //        BusinessState = e.BusinessState,
            //        SocialMedia = e.SocialMedia,
            //        GrowthGoals = e.GrowthGoals,
            //        BusinessGoals = e.BusinessGoals,
            //        CreatedOn = e.CreatedOn,
            //      ProfilePercentage = 25,// getprfilePercentage(e),
            //      RoleId = e.RoleId,
            //        RoleName = e.Role != null ? e.Role.RoleName : null,
            //      IsBookmark = e.TblBookMarkBookmarkByNavigation != null ? true : false
            //  }).ToList();
            //}




        }

        public List<MemberViewModel> GetMemberByRole(int roleid)
        {
            List<TblMember> memberlist = new List<TblMember>();

            if (roleid > 0)
            {
                memberlist = _entityDbContext.TblMember.Where(r => r.RoleId == roleid && r.IsDelete!=true)

                         .Include(s => s.Role)
                         .Include(s => s.TblBookMarkBookmarkByNavigation)
                         .ToList();
            }
            else
            {
                memberlist = _entityDbContext.TblMember.Where(r=>r.IsDelete != true)

                        .Include(s => s.Role)
                        .Include(s => s.TblBookMarkBookmarkByNavigation)
                        .ToList();
            }

           return memberlist.Select(e => new MemberViewModel
            {
                MemberId = e.MemberId,
                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
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
                CreatedOn = e.CreatedOn,
                ProfilePercentage = 25,// getprfilePercentage(e),
                RoleId = e.RoleId,
                RoleName = e.Role != null ? e.Role.RoleName : null,
               RoleIcon = e.RoleId == 1 ? Constant.MemberIcon : Constant.MemberIcon,
               IsBookmark = e.TblBookMarkBookmarkByNavigation.Count > 0 ? true : e.TblBookMarkBookmarkToNavigation.Count > 0 ? true : false
           }).ToList();

        }

        public List<RoleViewModel> GetMemberRoleDetails()
        {


            var employee = _entityDbContext.TblMemberRoles.Select(e => new RoleViewModel
            {
                RoleId = e.RoleId,
                RoleName = e.RoleName
            }).ToList();
            return employee;

        }

        public float getprfilePercentage(TblMember member)
        {
            // var count= member.
            return 25;
        }

        public string MemberBookmark(BookmrkViewModel model)
        {
            TblBookMark bookmark = new TblBookMark();

            if (model.BookmarkId > 0)
            {
                var result = _entityDbContext.TblBookMark.Where(e => e.BookmarkId == model.BookmarkId).FirstOrDefault();

                if (result != null)
                {
                    _entityDbContext.TblBookMark.Remove(result);
                    _entityDbContext.SaveChanges();
                    return "Unbookmark";
                }
            }
            else
            {

                bookmark.BookmarkBy = model.BookmarkBy;
                bookmark.BookmarkTo = model.BookmarkTo;
                bookmark.BookmarkDatet = DateTime.Now;
                bookmark.Type = model.Type;
                _entityDbContext.TblBookMark.Add(bookmark);
                _entityDbContext.SaveChanges();
                return "bookmark";
            }
            return Constant.Success;
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


        public MemberProfileViewModel GetEmployeeById(int memberid)
        {
            var employeedetails = _entityDbContext.TblMember.Where(x => x.MemberId == memberid && x.IsDelete != true)
                 .Include(s => s.Role)
            .Include(s => s.TblPostBookMark)
             .Include(s => s.TblBookMarkBookmarkByNavigation)
              .Include(s => s.TblMemberGoal)

              .Include(s => s.TblMemberSkills)
             .Include(s => s.TblMemberAttachment)
              .ThenInclude (s => s.TblMemberPhotoLikeComment)
                .ToList();

         return   employeedetails.Select(e => new MemberProfileViewModel
            {
                MemberId = e.MemberId,
                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
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
                CreatedOn = e.CreatedOn,
                RoleId = e.RoleId,
                RoleName = e.Role != null ? e.Role.RoleName : null,
             RoleIcon = e.RoleId == 1 ? Constant.MemberIcon : Constant.MemberIcon,
             Mission = e.Mission,
                LookingFor = e.LookingFor,
                Stage = e.Stage,
                Size = e.Size,
                Founded = Convert.ToDateTime(e.Founded).Year,
                IsBookmark = e.TblBookMarkBookmarkByNavigation.Count > 0 ? true : e.TblBookMarkBookmarkToNavigation.Count > 0 ? true : false,
                lstMemberGoal = e.TblMemberGoal.Count > 0 ? e.TblMemberGoal.Select(r => new MemberGoalViewModel
                {
                    GoalId = r.GoalId,
                    GoalName = r.GoalName
                }).ToList() : null,
                lstMemberSkills = e.TblMemberSkills.Count > 0 ? e.TblMemberSkills.Select(r => new MemberSkillsViewModel
                {
                    SkillId = r.SkillId,
                    SkillName = r.SkillName
                }).ToList() : null,
                lstMemberPostAttachment = e.TblMemberAttachment.Count > 0 ? e.TblMemberAttachment.Select(r => new MemberPostAttachmentViewModel
                {
                    AttachmentId = r.AttachmentId,
                    PhotoVideoUrl = Constant.livebaseurl + "MemberPost/" + r.PhotoVideoUrl,
                    CreateOn = r.CreateOn,
                    TotalLike = e.TblMemberPhotoLikeComment.Where(n => n.LikeUnlike == 1 && n.AttachmentId == r.AttachmentId && n.MemberId==memberid).Count(),
                    TotalUnlike = e.TblMemberPhotoLikeComment.Where(n => n.LikeUnlike == 2 && n.AttachmentId == r.AttachmentId && n.MemberId == memberid).Count(),
                    TotalComment = e.TblMemberPhotoLikeComment.Where(n => n.Comments != null && n.AttachmentId == r.AttachmentId && n.MemberId == memberid).Count(),
                }).ToList() : null,

            }).FirstOrDefault();
          
        }

        public string UploadMemberPostAttachment(List<TblMemberAttachment> attchment)
        {

            _entityDbContext.TblMemberAttachment.AddRange(attchment);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }

        public List<MemberViewModel> SearchMember(string search)
        {
            var employee = _entityDbContext.TblMember.Where(x =>x.IsDelete != true &&( x.FirstName.Contains(search) || x.LastName.Contains(search) || x.Mobile.Contains(search) || x.NickName.Contains(search))).Select(e => new MemberViewModel
            {
                MemberId = e.MemberId,
                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
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
                CreatedOn = e.CreatedOn,
                RoleId = e.RoleId,
                RoleName = e.Role != null ? e.Role.RoleName : null,
                RoleIcon = e.RoleId == 1 ? Constant.MemberIcon : Constant.MemberIcon,
                IsBookmark = e.TblBookMarkBookmarkByNavigation.Count > 0 ? true : e.TblBookMarkBookmarkToNavigation.Count > 0 ? true : false
            }).ToList();
            return employee;
        }

        public string PhotoVideoLikeComments(PhotoLikeCommentViewModel model)
        {
            TblMemberPhotoLikeComment photolikecomment = new TblMemberPhotoLikeComment();
            if (model.Id > 0)
                photolikecomment = GetPhotoLikeCommentById((int)model.Id);
            photolikecomment.LikeUnlike = model.LikeUnlike;
            photolikecomment.Comments = model.Comments;
            photolikecomment.MemberId = model.MemberId;
            photolikecomment.AttachmentId = model.AttachmentId;
            if (model.Id == 0)
            {
                photolikecomment.CreatedOn = DateTime.Now;
                photolikecomment.IsDeleted = false;
                _entityDbContext.TblMemberPhotoLikeComment.Add(photolikecomment);
            }
            _entityDbContext.SaveChanges();
            return Constant.Success;

        }
        public List<MemberViewModel> GetGroupListByFilter(MemberFilterViewModel model)
        {





            if (model.IsSaved == false)
            {

                return _entityDbContext.TblMember.Where(r => r.IsDelete != true && r.RoleId == model.RoleId).Select(e => new MemberViewModel
                {
                    MemberId = e.MemberId,
                    Email = e.Email,
                    Password = e.Password,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
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
                    CreatedOn = e.CreatedOn,
                    ProfilePercentage = 25,// getprfilePercentage(e),
                    RoleId = e.RoleId,
                    RoleName = e.Role != null ? e.Role.RoleName : null,
                    RoleIcon = e.RoleId == 1 ? Constant.MemberIcon : Constant.MemberIcon,
                    IsBookmark = e.TblBookMarkBookmarkByNavigation != null ? true : false
                }).ToList();
            }
            else
            {
                var bookmarksdetails = _entityDbContext.TblBookMark.Where(e => e.BookmarkBy == model.BookmarkBy).Select(k => k.BookmarkTo).ToList();

                //groupdetails = _entityDbContext.TblGroup.Where(r => r.IsDeleted != true && bookmarksdetails.Contains(r.GroupId)).ToList();

                return _entityDbContext.TblMember.Where(r => r.IsDelete != true && r.RoleId == model.RoleId && bookmarksdetails.Contains(r.MemberId)).Select(e => new MemberViewModel
                {
                    MemberId = e.MemberId,
                    Email = e.Email,
                    Password = e.Password,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
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
                    CreatedOn = e.CreatedOn,
                    ProfilePercentage = 25,// getprfilePercentage(e),
                    RoleId = e.RoleId,
                    RoleName = e.Role != null ? e.Role.RoleName : null,
                    RoleIcon = e.RoleId == 1 ? Constant.MemberIcon : Constant.MemberIcon,
                    IsBookmark = e.TblBookMarkBookmarkByNavigation != null ? true : false
                }).ToList();


            }



        }

        public MemberProfileViewModel Updateprofile(MemberProfileViewModel model)
        {
            var getMemberById = _entityDbContext.TblMember.Where(e => e.MemberId == model.MemberId && e.IsDelete!=true).FirstOrDefault();
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

            var employee = _entityDbContext.TblMember.Where(x => x.Email == email && x.IsDelete!=true).Select(e => new MemberLoginResponseViewModel
            {
                MemberId = e.MemberId,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileImage = Constant.livebaseurl + "Profiles/" + e.ProfileImage,
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
                CreatedOn = e.CreatedOn,
                RoleId = e.RoleId,
                RoleName = e.Role.RoleName,
                RoleIcon = e.RoleId == 1 ? Constant.MemberIcon : Constant.MemberIcon,
                IsBookmark = e.TblBookMarkBookmarkByNavigation.Count > 0 ? true : e.TblBookMarkBookmarkToNavigation.Count > 0 ? true : false
            }).FirstOrDefault();
            return employee;
        }

        public TblMemberPhotoLikeComment GetPhotoLikeCommentById(int id)
        {
            return _entityDbContext.TblMemberPhotoLikeComment.Where(e => e.Id == id).FirstOrDefault();
        }

    }
}
