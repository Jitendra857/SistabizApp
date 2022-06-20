using Microsoft.EntityFrameworkCore;
using SistabizApp.Authentication;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Experience = e.Experience,
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

        public List<MemberViewModel> GetCoachServiceProviderList()
        {
            List<TblMember> memberlist = new List<TblMember>();
           
                memberlist = _entityDbContext.TblMember.Where(r => r.IsDelete != true && (r.RoleId==2 || r.RoleId == 3))

                       
                        .ToList();
           
            return memberlist.Select(e => new MemberViewModel
            {
                MemberId = e.MemberId,
               
                FirstName = e.FirstName,
                LastName = e.LastName,
               
            }).ToList();



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
                Experience = e.Experience,
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
                if(subscription.SubscriptionId==0)
                _entityDbContext.TblUserSubscription.Add(subscription);
                _entityDbContext.SaveChanges();
                return subscription;
            }
            return subscription;
        }

        public TblBillingAddress AddBillingAddress(TblBillingAddress billingaddress)
        {
            if (billingaddress != null)
            {
                _entityDbContext.TblBillingAddress.Add(billingaddress);
                _entityDbContext.SaveChanges();
                return billingaddress;
            }
            return billingaddress;
        }
        public void CancelSubscription(int memberid=0)
        {
            var subscription= _entityDbContext.TblUserSubscription.Where(r => r.Userid == memberid && r.IsActive==true).FirstOrDefault();
            if (subscription != null)
            {
                subscription.IsActive = false;
                _entityDbContext.SaveChanges();
            }
        }
        public TblUserSubscription GetSubscriptionSubscription(int memberid = 0)
        {
           return _entityDbContext.TblUserSubscription.Where(r => r.Userid == memberid && r.IsActive == false).OrderByDescending(t=>t.SubscriptionId).FirstOrDefault();
           
        }

        public string RemoverMember(int memberid)
        {
            var member = _entityDbContext.TblMember.Where(e => e.MemberId == memberid).FirstOrDefault();
            if (member != null)
            {
                //_entityDbContext.TblMember.Remove(member);
                member.IsDelete = true;
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
              .Include(s=>s.TblBadgesAssignMember)
              .ThenInclude(s=>s.Badges)
              .Include(s=>s.TblMemberMatchesMember)
              .ThenInclude(s=>s.Member)
                .ToList();

         var memberdetails=   employeedetails.Select(e => new MemberProfileViewModel
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
                Experience = e.Experience,
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
                ProfilePercentage= GetNullProperiesCount(e),
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
             lstBadges= e.TblBadgesAssignMember.Count> 0?e.TblBadgesAssignMember.Select(r => new BadgesViewModel
             {
                 BadgesId = r.Badges.BadgesId,
                 BadgesName = r.Badges.BadgesName,
                 ImgaeUrl = Constant.livebaseurl + "Badges/" + r.Badges.Image,

             }).ToList():null,
             lstSistaSoulMatches = e.TblMemberMatchesMember.Count > 0 ? e.TblMemberMatchesMember.Select(r => new SistaSoulMatchesMembersModel
             {
                 Name = r.Member.FirstName+" "+r.Member.LastName,
                 Industry=r.Member.Industry,
                 Type=r.Type,
                 Business = r.Member.BusinessName,
                 Experience = r.Member.Experience,
                 ProfileUrl = Constant.livebaseurl + "Profiles/" + r.Member.ProfileImage,
                 CreatedOn=r.CreatedOn
                 
             }).ToList() : null,

         }).FirstOrDefault();

            var SistaInMonth = memberdetails.lstSistaSoulMatches!=null? memberdetails.lstSistaSoulMatches.Where(r => Convert.ToDateTime(r.CreatedOn).Date.Month == DateTime.Now.Month).FirstOrDefault():null;
            if (SistaInMonth != null)
            {
                memberdetails.SistaInMonth=SistaInMonth.Name+ " is your " + GetSistaById((int)SistaInMonth.Type) + " this month";
            }

            var EventName = _entityDbContext.TblEventRegisterMember.Where(r =>r.RegisterMemberId == memberdetails.MemberId)
                .Include(e=>e.Event)
                .FirstOrDefault();
            if (EventName != null)
            {
                memberdetails.EventAttendee = "You are both attending "+ EventName.Event.EventName +" event next Week";
            }
            var GroupName = _entityDbContext.TblGroupJoinMember.Where(r => r.JoinMemberId == memberdetails.MemberId)
                .Include(e=>e.Group)
                .FirstOrDefault();
            if (GroupName != null)
            {
                memberdetails.GroupAttende = "SYou are both member of the  " + GroupName.Group.GroupName + " Group";
            }
            return memberdetails;


        }
        public string GetSistaById(int type=0)
        {
            if (type == 1)
                return "Big Sista";
            if (type == 2)
                return "Littile Sista";
            if (type == 3)
                return "Wild Card";
            if (type == 4)
                return "Soul Sista";
            return "";
        }

        public float GetNullProperiesCount(object anyObject)
        {
            int count = 0;
            float percantage = 0;
            var objectDataContainer = anyObject.GetType().GetProperties().ToDictionary(i => i.Name, i => i.GetValue(anyObject));
            StringBuilder jsonfile = new StringBuilder();
            jsonfile.Append("{");
            var nullCount = 0;
            foreach (var data in objectDataContainer)
            {
                if(data.Key!= "IsDelete" && data.Key != "IsActive" && data.Key != "CreatedOn" && data.Key != "RoleId")
                if (data.Value != null)
                {
                    ++nullCount;
                  
                    if (count >= 34)
                        break;
                }
                count++;

            }
            percantage = 100 * nullCount / 34;
            var objType = anyObject.GetType();

            
            return percantage;
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
                Experience = e.Experience,
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
                    Experience = e.Experience,
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
                    Experience = e.Experience,
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
                if(model.Image!=null)
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
                getMemberById.Experience = model.Experience;
                getMemberById.GovernmentCertifications = model.GovernmentCertifications;
                getMemberById.EntityType = model.EntityType;
                getMemberById.BusinessState = model.BusinessState;
                getMemberById.SocialMedia = model.SocialMedia;
                getMemberById.GrowthGoals = model.GrowthGoals;
                getMemberById.BusinessGoals = model.BusinessGoals;
                getMemberById.Interest = model.Interest;
                getMemberById.Mission = model.Mission;
                getMemberById.LookingFor = model.LookingFor;
              

                _entityDbContext.SaveChanges();

               var matchessista = ManageMatches(model.Address, model.Industry, model.Interest, model.Experience, getMemberById.MemberId);
            }

            return model;
        }
        public string ManageMatches(string location, string indusrty, string intrest, double? experience, long? memberid)
        {
           List<TblMemberMatches> membermatch = new List<TblMemberMatches>();

            var gellallmembers = _entityDbContext.TblMember.Where(r=>r.IsDelete!=true && r.MemberId!=memberid).ToList();
            //Big Sistah 
            var bigsistamatchesmember = gellallmembers.Where(e => (e.City==location || e.Industry==indusrty || e.Interest==intrest) && e.Experience > experience).Select(r=>r.MemberId).ToList();
            if (bigsistamatchesmember.Count > 0)
            {
                foreach(var item in bigsistamatchesmember)
                {
                    var matchmember = _entityDbContext.TblMemberMatches.Where(t => t.MemberId == memberid && t.MatchesMemberid == item).FirstOrDefault();
                    if (matchmember == null)
                    {
                        membermatch.Add(new TblMemberMatches { MemberId = memberid, MatchesMemberid = item, Type = 1 });
                        _entityDbContext.TblMemberMatches.AddRange(membermatch);
                        _entityDbContext.SaveChanges();
                        membermatch = new List<TblMemberMatches>();
                    }

                }

            }
            

            //Lil Sistah
            var lilsistamatchesmember = gellallmembers.Where(e => (e.City == location || e.Industry == indusrty || e.Interest == intrest) && e.Experience < experience).Select(r => r.MemberId).ToList();
            if (lilsistamatchesmember.Count > 0)
            {
                foreach (var item in lilsistamatchesmember)
                {
                    var matchmember = _entityDbContext.TblMemberMatches.Where(t => t.MemberId == memberid && t.MatchesMemberid==item).FirstOrDefault();
                    if (matchmember == null)
                    {
                        membermatch.Add(new TblMemberMatches { MemberId = memberid, MatchesMemberid = item, Type = 2 });
                        _entityDbContext.TblMemberMatches.AddRange(membermatch);
                        _entityDbContext.SaveChanges();
                        membermatch = new List<TblMemberMatches>();
                    }

                }

            }
            
            // Wild Card
             var wildcardmatchesmember = gellallmembers.Where(e => e.City==location && (e.Industry!=indusrty && e.Interest!=intrest && e.Experience==null)).Select(r => r.MemberId).ToList();
            if (wildcardmatchesmember.Count > 0)
            {
                foreach (var item in wildcardmatchesmember)
                {
                    var matchmember = _entityDbContext.TblMemberMatches.Where(t => t.MemberId == memberid && t.MatchesMemberid == item).FirstOrDefault();
                    if (matchmember == null)
                    {
                        membermatch.Add(new TblMemberMatches { MemberId = memberid, MatchesMemberid = item, Type = 3 });
                        _entityDbContext.TblMemberMatches.AddRange(membermatch);
                        _entityDbContext.SaveChanges();
                        membermatch = new List<TblMemberMatches>();
                    }

                }

            }
           

            // Soul Sistah
            var soulsistahmatchesmember = gellallmembers.Where(e => e.City ==location && e.Industry==indusrty && e.Interest==intrest && e.Experience ==experience).Select(r => r.MemberId).ToList();
            if (soulsistahmatchesmember.Count > 0)
            {
                foreach (var item in soulsistahmatchesmember)
                {
                    var matchmember = _entityDbContext.TblMemberMatches.Where(t => t.MemberId == memberid && t.MatchesMemberid == item).FirstOrDefault();
                    if (matchmember == null)
                    {
                        membermatch.Add(new TblMemberMatches { MemberId = memberid, MatchesMemberid = item, Type = 4 });
                        _entityDbContext.TblMemberMatches.AddRange(membermatch);
                        _entityDbContext.SaveChanges();
                        membermatch = new List<TblMemberMatches>();
                    }

                }

            }
           
            return Constant.Success;
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
                Experience = e.Experience,
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
        public  bool UpdateDeviceToken(int memberid,string devicetoken)
        {
            var member = GetMemberDetailsById(memberid);
            var checkonbording = GetMemberOnboardingCount(memberid);
            if (member != null)
            {
                member.IsOnboarding = checkonbording==0? false:true;
                member.DeviceToken = devicetoken;
                _entityDbContext.SaveChanges();
            }
            return (bool)member.IsOnboarding;
        }

        public TblMemberPhotoLikeComment GetPhotoLikeCommentById(int id)
        {
            return _entityDbContext.TblMemberPhotoLikeComment.Where(e => e.Id == id).FirstOrDefault();
        }

        public string UpdateMemberPassword(string email=null,string password=null)
        {
            var result = _entityDbContext.TblMember.Where(e => e.Email == email).FirstOrDefault();
            if (result != null)
            {
                result.Password = password;
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }

        public TblMember GetMemberDetailsById(int memberid)
        {

            return _entityDbContext.TblMember.Where(e => e.MemberId == memberid && e.IsDelete!=true).FirstOrDefault();
        }

    }
}
