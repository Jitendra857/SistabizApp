using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMember
    {
        public TblMember()
        {
            TblAttachmentBookmark = new HashSet<TblAttachmentBookmark>();
            TblBadgesAssignMember = new HashSet<TblBadgesAssignMember>();
            TblBookMarkBookmarkByNavigation = new HashSet<TblBookMark>();
            TblBookMarkBookmarkToNavigation = new HashSet<TblBookMark>();
            TblBreakthrough = new HashSet<TblBreakthrough>();
            TblConversationQuestionAnswer = new HashSet<TblConversationQuestionAnswer>();
            TblDigitalLibrary = new HashSet<TblDigitalLibrary>();
            TblDigitalLibraryBookmark = new HashSet<TblDigitalLibraryBookmark>();
            TblEvent = new HashSet<TblEvent>();
            TblEventBookmark = new HashSet<TblEventBookmark>();
            TblEventRegisterMember = new HashSet<TblEventRegisterMember>();
            TblFaqQuestion = new HashSet<TblFaqQuestion>();
            TblFundingBookmark = new HashSet<TblFundingBookmark>();
            TblFundingResources = new HashSet<TblFundingResources>();
            TblGoal = new HashSet<TblGoal>();
            TblGoalMaches = new HashSet<TblGoalMaches>();
            TblGroup = new HashSet<TblGroup>();
            TblGroupBookmarks = new HashSet<TblGroupBookmarks>();
            TblGroupDiscussion = new HashSet<TblGroupDiscussion>();
            TblGroupJoinMember = new HashSet<TblGroupJoinMember>();
            TblGroupMeeting = new HashSet<TblGroupMeeting>();
            TblMemberAttachment = new HashSet<TblMemberAttachment>();
            TblMemberDesignation = new HashSet<TblMemberDesignation>();
            TblMemberGoal = new HashSet<TblMemberGoal>();
            TblMemberMatchesMatchesMember = new HashSet<TblMemberMatches>();
            TblMemberMatchesMember = new HashSet<TblMemberMatches>();
            TblMemberPhotoLikeComment = new HashSet<TblMemberPhotoLikeComment>();
            TblMemberPostLikeComment = new HashSet<TblMemberPostLikeComment>();
            TblMemberSkills = new HashSet<TblMemberSkills>();
            TblModule = new HashSet<TblModule>();
            TblOnboardingConversation = new HashSet<TblOnboardingConversation>();
            TblPost = new HashSet<TblPost>();
            TblPostBookMark = new HashSet<TblPostBookMark>();
            TblPostFeedback = new HashSet<TblPostFeedback>();
            TblReddemPointsMember = new HashSet<TblReddemPoints>();
            TblReddemPointsReddemByNavigation = new HashSet<TblReddemPoints>();
            TblServiceRequest = new HashSet<TblServiceRequest>();
            TblTeckHelpAssignByNavigation = new HashSet<TblTeckHelp>();
            TblTeckHelpAssignToNavigation = new HashSet<TblTeckHelp>();
            TblTeckHelpCreatedByNavigation = new HashSet<TblTeckHelp>();
            TblTestimonials = new HashSet<TblTestimonials>();
            TblUserSubscription = new HashSet<TblUserSubscription>();
        }

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
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
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
        public long? RoleId { get; set; }
        public string Stage { get; set; }
        public string Size { get; set; }
        public DateTime? Founded { get; set; }
        public string LookingFor { get; set; }
        public string ReferralCode { get; set; }
        public string Interest { get; set; }

        public virtual TblMemberRoles Role { get; set; }
        public virtual ICollection<TblAttachmentBookmark> TblAttachmentBookmark { get; set; }
        public virtual ICollection<TblBadgesAssignMember> TblBadgesAssignMember { get; set; }
        public virtual ICollection<TblBookMark> TblBookMarkBookmarkByNavigation { get; set; }
        public virtual ICollection<TblBookMark> TblBookMarkBookmarkToNavigation { get; set; }
        public virtual ICollection<TblBreakthrough> TblBreakthrough { get; set; }
        public virtual ICollection<TblConversationQuestionAnswer> TblConversationQuestionAnswer { get; set; }
        public virtual ICollection<TblDigitalLibrary> TblDigitalLibrary { get; set; }
        public virtual ICollection<TblDigitalLibraryBookmark> TblDigitalLibraryBookmark { get; set; }
        public virtual ICollection<TblEvent> TblEvent { get; set; }
        public virtual ICollection<TblEventBookmark> TblEventBookmark { get; set; }
        public virtual ICollection<TblEventRegisterMember> TblEventRegisterMember { get; set; }
        public virtual ICollection<TblFaqQuestion> TblFaqQuestion { get; set; }
        public virtual ICollection<TblFundingBookmark> TblFundingBookmark { get; set; }
        public virtual ICollection<TblFundingResources> TblFundingResources { get; set; }
        public virtual ICollection<TblGoal> TblGoal { get; set; }
        public virtual ICollection<TblGoalMaches> TblGoalMaches { get; set; }
        public virtual ICollection<TblGroup> TblGroup { get; set; }
        public virtual ICollection<TblGroupBookmarks> TblGroupBookmarks { get; set; }
        public virtual ICollection<TblGroupDiscussion> TblGroupDiscussion { get; set; }
        public virtual ICollection<TblGroupJoinMember> TblGroupJoinMember { get; set; }
        public virtual ICollection<TblGroupMeeting> TblGroupMeeting { get; set; }
        public virtual ICollection<TblMemberAttachment> TblMemberAttachment { get; set; }
        public virtual ICollection<TblMemberDesignation> TblMemberDesignation { get; set; }
        public virtual ICollection<TblMemberGoal> TblMemberGoal { get; set; }
        public virtual ICollection<TblMemberMatches> TblMemberMatchesMatchesMember { get; set; }
        public virtual ICollection<TblMemberMatches> TblMemberMatchesMember { get; set; }
        public virtual ICollection<TblMemberPhotoLikeComment> TblMemberPhotoLikeComment { get; set; }
        public virtual ICollection<TblMemberPostLikeComment> TblMemberPostLikeComment { get; set; }
        public virtual ICollection<TblMemberSkills> TblMemberSkills { get; set; }
        public virtual ICollection<TblModule> TblModule { get; set; }
        public virtual ICollection<TblOnboardingConversation> TblOnboardingConversation { get; set; }
        public virtual ICollection<TblPost> TblPost { get; set; }
        public virtual ICollection<TblPostBookMark> TblPostBookMark { get; set; }
        public virtual ICollection<TblPostFeedback> TblPostFeedback { get; set; }
        public virtual ICollection<TblReddemPoints> TblReddemPointsMember { get; set; }
        public virtual ICollection<TblReddemPoints> TblReddemPointsReddemByNavigation { get; set; }
        public virtual ICollection<TblServiceRequest> TblServiceRequest { get; set; }
        public virtual ICollection<TblTeckHelp> TblTeckHelpAssignByNavigation { get; set; }
        public virtual ICollection<TblTeckHelp> TblTeckHelpAssignToNavigation { get; set; }
        public virtual ICollection<TblTeckHelp> TblTeckHelpCreatedByNavigation { get; set; }
        public virtual ICollection<TblTestimonials> TblTestimonials { get; set; }
        public virtual ICollection<TblUserSubscription> TblUserSubscription { get; set; }
    }
}
