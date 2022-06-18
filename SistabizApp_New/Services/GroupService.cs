using Microsoft.EntityFrameworkCore;
using SistabizApp_New.Helper;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService
    {

        public List<GroupViewModel> GetGroupList()
        {
            //var grouplist = _entityDbContext.TblGroup.Where(r => r.IsDeleted != true)
            //    .Include(s=>s.TblGroupAttachment)
            //    .Include(s => s.TblGroupAttachment)
            //    .Include(s => s.TblGroupAttachment)
            //    .ToList();

            var eventdetails = _entityDbContext.TblGroup.Where(r => r.IsDeleted != true).Select(e => new GroupViewModel
            {
                GroupId = e.GroupId,
                GroupName = e.GroupName,
                Description = e.Description,
                CreatedBy = e.CreatedBy,
                CreatedOn = e.CreatedOn,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                IsActive = e.IsActive,
                IsDeleted = e.IsDeleted,
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                Type = e.Type,
                Category = e.Category,
                CategoryName = e.CategoryNavigation != null ? e.CategoryNavigation.CategoryName : null,
                Grouptype = CommanHelper.GetGroupType(e.Type),
                IsSaved = e.TblGroupBookmarks.Count > 0 ? true : false,
                GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.GroupIcon,
                lstGroupAttachmentViewModel = e.TblGroupAttachment.Count > 0 ? e.TblGroupAttachment.Select(r => new GroupAttachmentViewModel
                {
                    AttachmentId = r.AttachmentId,
                    Attachment = Constant.livebaseurl + "Groups/" + r.Attachment,
                    FileName =  r.Attachment,
                    Title =r.Title,
                    DocumentDescription=r.Description,
                    IsBookmark=r.TblAttachmentBookmark.Count>0?true:false
                    


                }).ToList() : null,
                lstGroupSavedMembers = e.TblGroupBookmarks.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                {
                    memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                    MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                }).ToList() : null,
                lstGroupJoinMembers = e.TblGroupJoinMember.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                {
                    JoinMemberId= t.JoinMember != null ? t.JoinMember.MemberId:0,
                    memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                    MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                }).ToList() : null,

                JoiningTotalMembers = e.TblGroupJoinMember.Count,
                // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).ToList();

            return eventdetails;
        }

        public List<GroupViewModel> GetGroupListBySearch(string search)
        {
            var eventdetails = _entityDbContext.TblGroup.Where(r => r.IsDeleted != true && r.GroupName.Contains(search)).Select(e => new GroupViewModel
            {
                GroupId = e.GroupId,
                GroupName = e.GroupName,
                Description = e.Description,
                CreatedBy = e.CreatedBy,
                CreatedOn = e.CreatedOn,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                IsActive = e.IsActive,
                IsDeleted = e.IsDeleted,
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                Type = e.Type,
                Category = e.Category,
                CategoryName = e.CategoryNavigation != null ? e.CategoryNavigation.CategoryName : null,
                Grouptype = CommanHelper.GetGroupType(e.Type),
                IsSaved = e.TblGroupBookmarks.Count > 0 ? true : false,
                GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.GroupIcon,
                lstGroupAttachmentViewModel = e.TblGroupAttachment.Count > 0 ? e.TblGroupAttachment.Select(r => new GroupAttachmentViewModel
                {
                    AttachmentId = r.AttachmentId,
                    Attachment = Constant.livebaseurl + "Groups/" + r.Attachment,
                    FileName = r.Attachment,
                    Title = r.Title,
                    DocumentDescription = r.Description,
                    IsBookmark = r.TblAttachmentBookmark.Count > 0 ? true : false


                }).ToList() : null,
                lstGroupSavedMembers = e.TblGroupBookmarks.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                {
                    memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                    MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                }).ToList() : null,
                lstGroupJoinMembers = e.TblGroupJoinMember.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                {
                    JoinMemberId = t.JoinMember != null ? t.JoinMember.MemberId : 0,
                    memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                    MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                }).ToList() : null,
                JoiningTotalMembers = e.TblGroupJoinMember.Count,
                // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).ToList();

            return eventdetails;
        }

        public GroupViewModel GetGroupDetailsById(int groupid)
        {
            var groupdetails = _entityDbContext.TblGroup.Where(r => r.IsDeleted != true && r.GroupId == groupid).Select(e => new GroupViewModel
            {
                GroupId = e.GroupId,
                GroupName = e.GroupName,
                Description = e.Description,
                CreatedBy = e.CreatedBy,
                CreatedOn = e.CreatedOn,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                IsActive = e.IsActive,
                IsDeleted = e.IsDeleted,
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                Type = e.Type,
                Category = e.Category,
                CategoryName = e.CategoryNavigation != null ? e.CategoryNavigation.CategoryName : null,
                Grouptype = CommanHelper.GetGroupType(e.Type),
                IsSaved = e.TblGroupBookmarks.Count > 0 ? true : false,
                GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.GroupIcon,
                lstGroupAttachmentViewModel = e.TblGroupAttachment.Count > 0 ? e.TblGroupAttachment.Select(r => new GroupAttachmentViewModel
                {
                    AttachmentId = r.AttachmentId,
                    Attachment = Constant.livebaseurl + "Groups/" + r.Attachment,
                    FileName = r.Attachment,
                    Title = r.Title,
                    DocumentDescription = r.Description,
                    IsBookmark = r.TblAttachmentBookmark.Count > 0 ? true : false


                }).ToList() : null,
                lstGroupJoinMembers = e.TblGroupBookmarks.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                {
                    memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                    MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                }).ToList() : null,
                JoiningTotalMembers = e.TblGroupJoinMember.Count,
                lstGroupMeeting=e.TblGroupMeeting.Count>0?e.TblGroupMeeting.Select(r=>new GroupmeetingViewModel
                {
                    MeetingId=r.MeetingId,
                    StartDateTime=r.StartDateTime,
                    EndDateTime=r.EndDateTime,
                    MeetingType=r.MeetingType,
                    MeetingPlace=r.MeetingPlace,
                    Agenda=r.Agenda,
                    Title=r.Title,
                    Description=r.Description,
                    CreatedOn=r.CreatedOn,
                    GroupMeetingType = CommanHelper.GetmeetingTypes(r.MeetingType),
                    MeetingLink=r.MeetingLink,
                }).ToList():null,
                lstGroupDiscussion = e.TblGroupDiscussion.Count > 0 ? e.TblGroupDiscussion.Select(t => new GroupDiscussionViewModel
                {
                   DiscussionId=t.DiscussionId,
                    Memberprofile = t.MessageByNavigation != null ? Constant.livebaseurl + "Profiles/" + t.MessageByNavigation.ProfileImage : null,
                    MemberName = t.MessageByNavigation != null ? t.MessageByNavigation.FirstName + " " + t.MessageByNavigation.LastName : null,
                    Message=t.Message
                }).OrderByDescending(k => k.DiscussionId).Take(5).ToList() : null,
                // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).FirstOrDefault();

            return groupdetails;
        }

        public List<GroupViewModel> GetGroupDetailsByMember(int memberid=0)
        {
            var groupdetails = new List<TblGroup>();
            if (memberid>0)
            {
                groupdetails = _entityDbContext.TblGroup.Where(r => r.IsDeleted != true && r.CreatedBy == memberid)
                    .Include(s => s.CreatedByNavigation)
                     .Include(s => s.TblGroupAttachment)
                      .Include(s => s.TblGroupBookmarks)
                       .Include(s => s.TblGroupJoinMember)
                       .ThenInclude(s=>s.JoinMember)
                    .ToList();
            }
            else
            {
                groupdetails = _entityDbContext.TblGroup.Where(r => r.IsDeleted != true && r.StartDate > DateTime.Now.Date)
                   .Include(s => s.CreatedByNavigation)
                    .Include(s => s.TblGroupAttachment)
                     .Include(s => s.TblGroupBookmarks)
                      .Include(s => s.TblGroupJoinMember)
                      .ThenInclude(s => s.JoinMember)
                   .ToList();
            }

           return groupdetails.Select(e => new GroupViewModel
            {
                GroupId = e.GroupId,
                GroupName = e.GroupName,
                Description = e.Description,
                CreatedBy = e.CreatedBy,
                CreatedOn = e.CreatedOn,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                IsActive = e.IsActive,
                IsDeleted = e.IsDeleted,
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                Type = e.Type,
                Category = e.Category,
                CategoryName = e.CategoryNavigation != null ? e.CategoryNavigation.CategoryName : null,
                Grouptype = CommanHelper.GetGroupType(e.Type),
                IsSaved = e.TblGroupBookmarks.Count > 0 ? true : false,
                GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.GroupIcon,
                lstGroupAttachmentViewModel = e.TblGroupAttachment.Count > 0 ? e.TblGroupAttachment.Select(r => new GroupAttachmentViewModel
                {
                    AttachmentId = r.AttachmentId,
                    Attachment = Constant.livebaseurl + "Groups/" + r.Attachment,
                    FileName = r.Attachment,
                    Title = r.Title,
                    DocumentDescription = r.Description,
                    IsBookmark = r.TblAttachmentBookmark.Count > 0 ? true : false


                }).ToList() : null,
               lstGroupSavedMembers = e.TblGroupBookmarks.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
               {
                   memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                   MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
               }).ToList() : null,
               lstGroupJoinMembers = e.TblGroupJoinMember.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
               {
                   JoinMemberId = t.JoinMember != null ? t.JoinMember.MemberId : 0,
                   memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                   MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
               }).ToList() : null,
               JoiningTotalMembers = e.TblGroupJoinMember.Count,
                // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).ToList();

           
        }

        public List<GroupCategoryViewModel> GetAllCategory()
        {
            return _entityDbContext.TblGroupCategory.Select(e => new GroupCategoryViewModel
            {
                CategoryId = e.GroupCategoryId,
                CategoryName = e.CategoryName

            }).ToList();
        }

        public List<GroupDiscussionViewModel> GetGroupDiscussionList(int groupid)
        {
            //var groupdiscussion = _entityDbContext.TblGroup.Where(r => r.GroupId == groupid)
            //     .Include(s => s.TblGroupJoinMember)
            //     .ThenInclude(s=>s.JoinMember)
            //     .Include(s=>s.TblGroupDiscussion)
            //     .ThenInclude(s=>s.MessageByNavigation)
            //     .ToList();

            var groupdiscussion = _entityDbContext.TblGroupDiscussion.Where(r => r.GroupId == groupid)
                .Include(s => s.MessageByNavigation)
                //.ThenInclude(s => s.JoinMember)
                //.Include(s => s.TblGroupDiscussion)
                //.ThenInclude(s => s.MessageByNavigation)
                .ToList();

            return groupdiscussion.Select(t => new GroupDiscussionViewModel
            {
                Memberprofile = t.MessageByNavigation != null ? Constant.livebaseurl + "Profiles/" + t.MessageByNavigation.ProfileImage : null,
                MemberName = t.MessageByNavigation != null ? t.MessageByNavigation.FirstName + " " + t.MessageByNavigation.LastName : null,
                Message = t.Message,
                CreatedOn=t.CreatedOn
            }).OrderByDescending(k => k.DiscussionId).ToList();
          
        }

        public List<GroupViewModel> GetGroupListByFilter(GroupFilterViewModel model)
        {


            if (model.IsSaved == false)
            {
                return _entityDbContext.TblGroup.Where(r => r.IsDeleted != true && r.Category == model.CategoryId).Select(e => new GroupViewModel
                {
                    GroupId = e.GroupId,
                    GroupName = e.GroupName,
                    Description = e.Description,
                    CreatedBy = e.CreatedBy,
                    CreatedOn = e.CreatedOn,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    IsActive = e.IsActive,
                    IsDeleted = e.IsDeleted,

                    CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                    CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                    Type = e.Type,
                    Category = e.Category,
                    CategoryName = e.CategoryNavigation != null ? e.CategoryNavigation.CategoryName : null,
                    Grouptype = CommanHelper.GetGroupType(e.Type),
                    IsSaved = e.TblGroupBookmarks.Count > 0 ? true : false,
                    GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.GroupIcon,
                    lstGroupAttachmentViewModel = e.TblGroupAttachment.Count > 0 ? e.TblGroupAttachment.Select(r => new GroupAttachmentViewModel
                    {
                        AttachmentId = r.AttachmentId,
                        Attachment = Constant.livebaseurl + "Groups/" + r.Attachment,
                        FileName = r.Attachment,
                        Title = r.Title,
                        DocumentDescription = r.Description,
                        IsBookmark = r.TblAttachmentBookmark.Count > 0 ? true : false


                    }).ToList() : null,
                    lstGroupSavedMembers = e.TblGroupBookmarks.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                    {
                        memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                        MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                    }).ToList() : null,
                    lstGroupJoinMembers = e.TblGroupJoinMember.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                    {
                        JoinMemberId = t.JoinMember != null ? t.JoinMember.MemberId : 0,
                        memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                        MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                    }).ToList() : null,
                    JoiningTotalMembers = e.TblGroupJoinMember.Count,
                    // CreatedByMember=e.TblEventRegisterMember!=null?e.t

                }).ToList();
                //groupdetails = groupdetails.Where(r => r.IsDeleted != true && r.Category == model.CategoryId).ToList();
            }
            else
            {
                var bookmarksdetails = _entityDbContext.TblGroupBookmarks.Where(e => e.MemberId == model.MemberId && e.CategoryId == model.CategoryId).Select(k => k.GroupId).ToList();

                //groupdetails = _entityDbContext.TblGroup.Where(r => r.IsDeleted != true && bookmarksdetails.Contains(r.GroupId)).ToList();

                return _entityDbContext.TblGroup.Where(r => r.IsDeleted != true && bookmarksdetails.Contains(r.GroupId)).Select(e => new GroupViewModel
                {
                    GroupId = e.GroupId,
                    GroupName = e.GroupName,
                    Description = e.Description,
                    CreatedBy = e.CreatedBy,
                    CreatedOn = e.CreatedOn,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    IsActive = e.IsActive,
                    IsDeleted = e.IsDeleted,
                    CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                    CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                    Type = e.Type,
                    Category = e.Category,
                    CategoryName = e.CategoryNavigation != null ? e.CategoryNavigation.CategoryName : null,
                    Grouptype = CommanHelper.GetGroupType(e.Type),
                    IsSaved = e.TblGroupBookmarks.Count > 0 ? true : false,
                    GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.GroupIcon,
                    lstGroupAttachmentViewModel = e.TblGroupAttachment.Count > 0 ? e.TblGroupAttachment.Select(r => new GroupAttachmentViewModel
                    {
                        AttachmentId = r.AttachmentId,
                        Attachment = Constant.livebaseurl + "Groups/" + r.Attachment,
                        FileName = r.Attachment,
                        Title = r.Title,
                        DocumentDescription = r.Description,
                        IsBookmark = r.TblAttachmentBookmark.Count > 0 ? true : false


                    }).ToList() : null,
                    lstGroupSavedMembers = e.TblGroupBookmarks.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                    {
                        memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                        MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                    }).ToList() : null,
                    lstGroupJoinMembers = e.TblGroupJoinMember.Count > 0 ? e.TblGroupJoinMember.Select(t => new GroupJoinMemberViewModel
                    {
                        JoinMemberId = t.JoinMember != null ? t.JoinMember.MemberId : 0,
                        memberprofile = t.JoinMember != null ? Constant.livebaseurl + "Profiles/" + t.JoinMember.ProfileImage : null,
                        MemberName = t.JoinMember != null ? t.JoinMember.FirstName + " " + t.JoinMember.LastName : null
                    }).ToList() : null,
                    JoiningTotalMembers = e.TblGroupJoinMember.Count,
                    // CreatedByMember=e.TblEventRegisterMember!=null?e.t

                }).ToList();
            }



        }

        public long ManageGroup(GroupViewModel model)
        {
            TblGroup group = new TblGroup();
            if (model.GroupId > 0)
                group = GetById((int)model.GroupId);

            group.GroupName = model.GroupName;
            group.Description = model.Description;
            group.Type = model.Type;
            group.CreatedBy = model.CreatedBy;
            group.CreatedOn = DateTime.Now;
            group.Category = model.Category;
            group.IsActive = true;
            group.IsDeleted = false;
            group.GroupIcon = model.GroupIconPath;
            group.StartDate = model.StartDate;
            group.EndDate = model.EndDate;


            if (model.GroupId == 0)
                _entityDbContext.TblGroup.Add(group);

            _entityDbContext.SaveChanges();
            return group.GroupId;
        }

        public string ManageGroupMeeting(GroupmeetingViewModel model)
        {
            TblGroupMeeting groupmeeting = new TblGroupMeeting();
            if (model.MeetingId > 0)
                groupmeeting = GetByGroupMeetingId((int)model.MeetingId);
            var date = DateTime.Now;
            groupmeeting.StartDateTime = model.StartDateTime;
            groupmeeting.EndDateTime = model.EndDateTime;
            groupmeeting.MeetingType = model.MeetingType;
            groupmeeting.MeetingPlace = model.MeetingPlace;
            groupmeeting.Agenda =model.Agenda;
            groupmeeting.Title = model.Title;
            groupmeeting.Description = model.Description;
            groupmeeting.GroupId = model.GroupId;
            groupmeeting.CreatedBy = model.CreatedBy;
            groupmeeting.CreatedOn = DateTime.Now;
            groupmeeting.MeetingLink =model.MeetingLink;

            if (model.MeetingId == 0)
                _entityDbContext.TblGroupMeeting.Add(groupmeeting);

            _entityDbContext.SaveChanges();
            return Constant.Success;
        }

        public string DeleteGroupMeeting(int id)
        {
            var groupmeeting = _entityDbContext.TblGroupMeeting.Where(r => r.MeetingId == id).FirstOrDefault();
            if (groupmeeting != null)
            {
                _entityDbContext.TblGroupMeeting.Remove(groupmeeting);
                _entityDbContext.SaveChanges();
            }

            _entityDbContext.SaveChanges();
            return Constant.Success;
        }

        public GroupmeetingViewModel GetMeetingDetails(int id)
        {
            return _entityDbContext.TblGroupMeeting.Where(r => r.MeetingId == id).Select(r => new GroupmeetingViewModel
            {
                MeetingId = r.MeetingId,
                StartDateTime = r.StartDateTime,
                EndDateTime = r.EndDateTime,
                MeetingType = r.MeetingType,
                MeetingPlace = r.MeetingPlace,
                Agenda = r.Agenda,
                Title = r.Title,
                Description = r.Description,
                CreatedOn = r.CreatedOn,
                GroupMeetingType = CommanHelper.GetmeetingTypes(r.MeetingType),
            }).FirstOrDefault();
        }

        public string GroupDiscussion(GroupDiscussionViewModel model)
        {
            TblGroupDiscussion groupdiscussion = new TblGroupDiscussion();
            
            var date = DateTime.Now;
            groupdiscussion.Message = model.Message;
            groupdiscussion.MessageBy = model.MessageBy;
            groupdiscussion.GroupId = model.GroupId;
            groupdiscussion.CreatedOn = DateTime.Now;
           
                _entityDbContext.TblGroupDiscussion.Add(groupdiscussion);

            _entityDbContext.SaveChanges();
            return Constant.Success;
        }


        public string UploadGroupAttachment(List<TblGroupAttachment> attchment)
        {

            _entityDbContext.TblGroupAttachment.AddRange(attchment);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }
        public GroupJoinMemberViewModel GroupJoinMembers(GroupJoinMemberViewModel model)
        {
            TblGroupJoinMember joinmember = new TblGroupJoinMember();
            joinmember.GroupId = model.GroupId;
            joinmember.JoinMemberId = model.JoinMemberId;
            if (string.IsNullOrEmpty(model.LeavingDate.ToString()))
            {
                joinmember.JoinDate = Convert.ToDateTime(model.JoinDate);
                joinmember.IsActive = true;
            }
            else
            {
                joinmember.LeavingDate = Convert.ToDateTime(model.LeavingDate);
                joinmember.IsActive = false;
            }

            _entityDbContext.TblGroupJoinMember.Add(joinmember);

            _entityDbContext.SaveChanges();

            //member earn point
            RedeemPointsViewModel reddem = new RedeemPointsViewModel();
            reddem.MemberId = model.JoinMemberId;
            reddem.Description = "Earn Point By Join A Group";
            reddem.ReddemPoint = 25;
            RedeemEarnPointOtherActivity(reddem);

            return model;
        }

        public string GroupBookmark(GroupBookmarkViewModel model)
        {
            TblGroupBookmarks bookmark = new TblGroupBookmarks();

            if (model.BookmarkId > 0)
            {
                var result = _entityDbContext.TblGroupBookmarks.Where(e => e.BookmarkId == model.BookmarkId).FirstOrDefault();

                if (result != null)
                {
                    _entityDbContext.TblGroupBookmarks.Remove(result);
                    _entityDbContext.SaveChanges();
                    return "Unbookmark";
                }
            }
            else
            {
                bookmark.MemberId = model.MemberId;
                bookmark.CategoryId = model.CategoryId;
                bookmark.GroupId = model.GroupId;
                _entityDbContext.TblGroupBookmarks.Add(bookmark);
                _entityDbContext.SaveChanges();
                return "bookmark";
            }
            return "bookmark";
        }

        public string GroupAttachmentBookmark(GroupAttachmentBookmarkViewModel model)
        {
            TblAttachmentBookmark bookmark = new TblAttachmentBookmark();

            if (model.BookmarkId > 0)
            {
                var result = _entityDbContext.TblAttachmentBookmark.Where(e => e.BookmarkId == model.BookmarkId).FirstOrDefault();

                if (result != null)
                {
                    _entityDbContext.TblAttachmentBookmark.Remove(result);
                    _entityDbContext.SaveChanges();
                    return "Unbookmark";
                }
            }
            else
            {
                bookmark.MemberId = model.MemberId;
               
                bookmark.AttachmentId = model.AttachmentId;
                _entityDbContext.TblAttachmentBookmark.Add(bookmark);
                _entityDbContext.SaveChanges();
                return "bookmark";
            }
            return "bookmark";
        }

        public List<TblGroupJoinMember> AddGroupMembers(List<TblGroupJoinMember> model)
        {
            TblGroupJoinMember joinmember = new TblGroupJoinMember();
            //joinmember.GroupId = model.GroupId;
            //joinmember.JoinMemberId = model.JoinMemberId;
            //if (string.IsNullOrEmpty(model.LeavingDate.ToString()))
            //{
            //    joinmember.JoinDate = Convert.ToDateTime(model.JoinDate);
            //    joinmember.IsActive = true;
            //}
            //else
            //{
            //    joinmember.LeavingDate = Convert.ToDateTime(model.LeavingDate);
            //    joinmember.IsActive = false;
            //}

            _entityDbContext.TblGroupJoinMember.AddRange(model);

            _entityDbContext.SaveChanges();
            return model;
        }

        public string RemoveGroup(int groupid)
        {
            var group = GetById(groupid);
            if (group != null)
            {
                group.IsDeleted = true;
                _entityDbContext.SaveChanges();
            }
            return "Success";
        }

        public TblGroup GetById(int groupid)
        {
            return _entityDbContext.TblGroup.Where(e => e.GroupId == groupid).FirstOrDefault();
        }
        public TblGroupMeeting GetByGroupMeetingId(int meetingid)
        {
            return _entityDbContext.TblGroupMeeting.Where(e => e.MeetingId == meetingid).FirstOrDefault();
        }

    }
}
