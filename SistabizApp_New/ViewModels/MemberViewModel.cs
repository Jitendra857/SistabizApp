using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class MemberViewModel
    {
        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public long? StateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string ProfileImage { get; set; }
        public string AboutMe { get; set; }
        public string BusinessName { get; set; }
        public string WebsiteUrl { get; set; }
        public string AboutBusiness { get; set; }
        public int? BusinessType { get; set; }
        public string Industry { get; set; }
        public int? CustomerType { get; set; }
        public int? YearsInBusiness { get; set; }
        public double? Experience { get; set; }
        public string GovernmentCertifications { get; set; }
        public int? EntityType { get; set; }
        public string BusinessState { get; set; }
        public string SocialMedia { get; set; }
        public string GrowthGoals { get; set; }
        public string BusinessGoals { get; set; }
        public IFormFile Image { get; set; }
        public List<IFormFile> PostImageAndVideo { get; set; } = new List<IFormFile>();
        public float ProfilePercentage { get; set; }
        public long? RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleIcon { get; set; }
        public bool IsBookmark { get; set; }
    }

    public class MemberProfileViewModel
    {
        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public long? StateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string ProfileImage { get; set; }
        public string AboutMe { get; set; }
        public string Mission { get; set; }
        public string BusinessName { get; set; }
        public string WebsiteUrl { get; set; }
        public string AboutBusiness { get; set; }
        public int? BusinessType { get; set; }
        public string Industry { get; set; }
        public int? CustomerType { get; set; }
        public int? YearsInBusiness { get; set; }
        public double? Experience { get; set; }
        public string GovernmentCertifications { get; set; }
        public int? EntityType { get; set; }
        public string BusinessState { get; set; }
        public string SocialMedia { get; set; }
        public string GrowthGoals { get; set; }
        public string BusinessGoals { get; set; }
        public IFormFile Image { get; set; }
        public List<IFormFile> PostImageAndVideo { get; set; } = new List<IFormFile>();
        public float ProfilePercentage { get; set; }
        public long? RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleIcon { get; set; }
        public string Stage { get; set; }
        public string Size { get; set; }
        public int Founded { get; set; }
        public string LookingFor { get; set; }
        public bool IsBookmark { get; set; }
        public string SistaInMonth { get; set; }
        public string EventAttendee { get; set; }
        public string GroupAttende { get; set; }
        public List<MemberGoalViewModel> lstMemberGoal { get; set; } = new List<MemberGoalViewModel>();
        public string Interest { get; set; }
        public List<MemberSkillsViewModel> lstMemberSkills { get; set; } = new List<MemberSkillsViewModel>();
        public List<MemberPostAttachmentViewModel> lstMemberPostAttachment { get; set; } = new List<MemberPostAttachmentViewModel>();
        public List<BadgesViewModel> lstBadges { get; set; } = new List<BadgesViewModel>();
        public List<SistaSoulMatchesMembersModel> lstSistaSoulMatches { get; set; } = new List<SistaSoulMatchesMembersModel>();


    }
    public class MemberGoalViewModel
    {
        public long GoalId { get; set; }
        public string GoalName { get; set; }
    }
    public class MemberSkillsViewModel
    {
        public long SkillId { get; set; }
        public string SkillName { get; set; }
    }
    public class MemberPostAttachmentViewModel
    {
        public long AttachmentId { get; set; }
        public string PhotoVideoUrl { get; set; }
        public long? MemberId { get; set; }
        public DateTime? CreateOn { get; set; }
        public int TotalLike { get; set; } = 0;
        public int TotalUnlike { get; set; } = 0;
        public int TotalComment { get; set; } = 0;
    }
    public class MemberFilterViewModel
    {
        public long? RoleId { get; set; }
        public long? BookmarkBy { get; set; }
        public long? BookmarkTo { get; set; }
        public bool IsSaved { get; set; } = false;
        public int Ordering { get; set; } = 0;

    }

    public class BookmrkViewModel
    {
        public long BookmarkId { get; set; }
        public long? BookmarkBy { get; set; }
        public long? BookmarkTo { get; set; }
        public DateTime? BookmarkDatet { get; set; }
        public int? Type { get; set; }
    }
    public class MemberLoginResponseViewModel
    {
        public long MemberId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string ProfileImage { get; set; }
        public string AboutMe { get; set; }
        public string BusinessName { get; set; }
        public string WebsiteUrl { get; set; }
        public string AboutBusiness { get; set; }
        public int? BusinessType { get; set; }
        public string Industry { get; set; }
        public int? CustomerType { get; set; }
        public int? YearsInBusiness { get; set; }
        public double? Experience { get; set; }
        public string GovernmentCertifications { get; set; }
        public int? EntityType { get; set; }
        public string BusinessState { get; set; }
        public string SocialMedia { get; set; }
        public string GrowthGoals { get; set; }
        public string BusinessGoals { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public long? RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleIcon { get; set; }
        public bool IsBookmark { get; set; }
    }

    public class RoleViewModel
    {
        public long? RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class GroupmeetingViewModel
    {
        public long MeetingId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? MeetingType { get; set; }
        public string MeetingPlace { get; set; }
        public string Agenda { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? GroupId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string GroupMeetingType { get; set; }
        public string MeetingLink { get; set; }
    }



    public class PhotoLikeCommentViewModel
    {
        public long Id { get; set; }
        public long? AttachmentId { get; set; }
        public long? MemberId { get; set; }
        public int? LikeUnlike { get; set; }
        public string Comments { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }

    }

    public class SistaSoulMatchesMembersModel
    {
        public string Name { get; set; }
        public string ProfileUrl { get; set; }
        public int? Type { get; set; } = 0;
        public string Industry { get; set; }
        public string Location { get; set; }
        public string Business { get; set; }
        public double? Experience { get; set; } = 0;
        public DateTime? CreatedOn { get; set; }
    }
}
