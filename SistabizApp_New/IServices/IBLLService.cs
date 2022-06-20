using SistabizApp.Authentication;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.IServices
{
  public  interface IBLLService
    {

        //service proivider
        ServiceRequestViewModel AddServiceRequest(ServiceRequestViewModel serviceRequest);
        List<ServiceRequestViewModel> GetServiceRequestList();
        TblServiceRequest GetServiceRequestById(int RequestId);

        List<ServiceRequestViewModel> GetServiceRequestListByStatus(int Status);
        string AcceptRejectServiceRequest(ServiceRequestChangeViewModel model);
        List<ServiceRequestViewModel> GetServiceRequestListByMember(int MemberId);

        //end service provider

        void SaveChanges();

        //employee

        List<MemberViewModel> MemberList(string search=null);
        TblMember AddEmployee(TblMember employee);
        MemberProfileViewModel Updateprofile(MemberProfileViewModel model);
        string UploadMemberPostAttachment(List<TblMemberAttachment> attchment);
        List<RoleViewModel> GetMemberRoleDetails();
        string RemoverMember(int memberid);
        MemberProfileViewModel GetEmployeeById(int memberid);
        List<MemberViewModel> SearchMember(string search);
        MemberLoginResponseViewModel GetMemberByEmail(string email);
        bool UpdateDeviceToken(int memberid, string devicetoken);
        string UpdateMemberPassword(string email = null, string password = null);

        TblUserSubscription AddSubscription(TblUserSubscription subscription);
        TblBillingAddress AddBillingAddress(TblBillingAddress billingaddress);
        string ManageBreakThrough(TblBreakthrough breakthrough);
        List<BreathroughModel> GetAllBreakThroughList();
        BreathroughModel GetAllBreakThroughListById(int id);
        string UpdateBreakthrough(int id);
        void CancelSubscription(int memberid = 0);

        List<MemberViewModel> GetMemberByRole(int roleid);
        string MemberBookmark(BookmrkViewModel model);
        List<MemberViewModel> GetGroupListByFilter(MemberFilterViewModel model);
        string PhotoVideoLikeComments(PhotoLikeCommentViewModel model);
        List<MemberViewModel> GetCoachServiceProviderList();
        TblMember GetMemberDetailsById(int memberid);

        TblUserSubscription GetSubscriptionSubscription(int memberid = 0);

        //end employee

        //event 

        List<EventResponseViewModel> GetEventList();
        List<EventResponseViewModel> SearchEventList(string search);
        EventResponseViewModel GetEventListById(int eventid);
        long ManageEvent(EventViewModel model);

        string UploadEventAttachment(List<TblEventAttachment> attchment);

        RegisterMemberEventViewModel RegisterEventMember(RegisterMemberEventViewModel model);

        string UpdateEventStatus(RegisterMemberEventViewModel model);

        string DeleteEvent(int eventid);
        string DeleteEventAttachment(int eventid);
        List<EventResponseViewModel> GetEventListByFilter(EventFilterViewModel model);
        string EventBookmark(EventBookmarkViewModel model);

        //end event

        //funding resources
        List<FundingCategoryViewModel> GetAllFundingCategory();

        List<FundingViewModel> GetAllFundingResource();
        string FundingResourceBookmark(FundingBookmarkViewModel model);
        List<FundingViewModel> GetAllFundingResourceByCategory(int categoryid);
        List<FundingViewModel> GetAllFundingResourceByDate(string date);
        FundingViewModel GetAllFundingResourceById(int id);

        string ManageFundingResources(FundingViewModel model);
        List<FundingViewModel> SearchFundingResource(string search);

        string DeleteFundingResource(int fundingid);

        //funding section
        FundingTitleViewModel GetFundingTitleDetails();
        string ManageFundingTitle(FundingTitleViewModel model);
        string DeleteFundingTitle(int id);


        // faq
        List<FaqCategoryViewModel> GetAllFaqCategory();
        List<FaqViewModel> GetAllFaq(string search = null);
        List<FaqCategoryViewModel> GetAllFaqByCategory();

        string ManageFaq(FaqViewModel model);

        string DeleteFaq(int id);

        //faq question
        List<FaqQuestionViewModel> GetFaqQuestionList();
        string ManageFaqQuestion(FaqQuestionViewModel model);
        string DeleteFaqQuestion(int fundingid);

        // post
        List<PostViewModel> GetAllPost();
        PostViewModel GetPostDetails();
        List<PostViewModel> GetAllPostByMember(int memberid = 0);
        List<PostViewModel> GetAllSavedPost(int memberid = 0);
        long ManagePost(PostViewModel model);
        string DeletePost(int id);
        string UploadPostAttachment(List<TblPostAttachment> attchment);
        string PostLikeComments(PostLikeCommentsViewModel model);
        string PostBookmark(PostBookmarkViewModel model);

        //group
        List<GroupViewModel> GetGroupList();
        GroupViewModel GetGroupDetailsById(int groupid);
        long ManageGroup(GroupViewModel model);
        List<GroupViewModel> GetGroupListBySearch(string search);
        string UploadGroupAttachment(List<TblGroupAttachment> attchment);
        GroupJoinMemberViewModel GroupJoinMembers(GroupJoinMemberViewModel model);
        string GroupBookmark(GroupBookmarkViewModel model);
        string GroupAttachmentBookmark(GroupAttachmentBookmarkViewModel model);
        List<GroupViewModel> GetGroupListByFilter(GroupFilterViewModel model);
        List<GroupCategoryViewModel> GetAllCategory();
        List<GroupViewModel> GetGroupDetailsByMember(int memberid=0);
        List<GroupDiscussionViewModel> GetGroupDiscussionList(int groupid=0);

        string RemoveGroup(int groupid);
        string ManageGroupMeeting(GroupmeetingViewModel model);
        string GroupDiscussion(GroupDiscussionViewModel model);

        List<TblGroupJoinMember> AddGroupMembers(List<TblGroupJoinMember> model);
        string DeleteGroupMeeting(int id);
        GroupmeetingViewModel GetMeetingDetails(int id);

        //goal and activity
        List<GoalActivityViewModel> GetAllGoalAndActivity(int memberid, string year = null);
        string ManageGoalActivity(GoalActivityViewModel model);
        string RemoveGoal(int goalid);
        string GoalPostpone(GoalPostponeViewModel model);
        string GoalCompleted(GoalCompletedViewModel model);
        List<GoalActivityViewModel> GetAllGoalAndActivityByDate(string date);

        //country/state
        List<CountryViewModel> GetAllCountry();
        List<StateViewModel> GetAllState();
        List<StateViewModel> GetStateByCountry(int countryid);

        // digital library
        List<DigitalLibraryViewModel> GetDigitalLibraryList(string search = null);
        DigitalLibraryViewModel GetDigitalLibraryDetailsById(int id);
        List<DigitalLibraryViewModel> GetDigitalLibraryListByCategory(int category);
        long ManageDigitalLibrary(DigitalLibraryViewModel model);
        List<DigitalLibraryCategoryViewModel> GetCategoryList();
        string UploadDigitalLibraryAttachment(List<TblDigitalLibaryAttachment> attchment);
        string RemoveDigitalLibrary(int digitallibraryid);
        string DigitalLibraryBookmark(DigitalLibraryBookmarkViewModel model);
        List<DigitalLibraryViewModel> GetGroupListByFilter(DigitalLibraryFilterViewModel model);


        //onbording conversation
        List<QuestionViewModel> GetAllConversationQuestion();
        List<QuestionViewModel> GetAllQuestionAnswer();
        string ManageQuestionAnswer(List<QuestionAnswerViewModel> model);
        int GetMemberOnboardingCount(int memberid = 0);

        //comman
        List<CommanViewModel> GetBookmarkList(int typeid, int memberid);

        //Testimonials
        List<TestimonialsResponseViewModel> getAllTestimonialsList(int memberid);

        //tech help
        List<TechHelpViewModel> GetTechhelpDetails(int memberid = 0);
        string ManageTechHelp(TechHelpRequestViewModel model);
        string AssignTechHelp(TechHelpAssignedViewModel model);

        //module parmission
        List<SubscriptionViewModel> GetSubscriptionList();
        string AssingModulePermission(ModulePermissionViewModel model);
        List<ModuleViewModel> GetModuleList();
        string ManageModule(ModuleViewModel model);
        string DeleteModule(int id);

        //Badges
        List<BadgesViewModel> GetAllBadges();
        string ManageBadges(BadgesViewModel model);
        string RemoveBadges(int badgesid = 0);
        string ReassignBadges(int badgesid = 0, int memberid = 0);
        bool BadgesAssignMember(BadgesAssignViewMidel model);
        List<BadgesViewModel> GetAllBadgesByMember(int memberid = 0);

        //chat history
        List<ChatViewModel> GetChatHistory();
        string ManageChat(ChatViewModel model);

        //redeem points
        List<RedeemPointsDetailsViewModel> GetAllRedeemPoint();
        MemberErnsPointModel GetAllRedeemPointByMember(int memberid = 0);
        string RedeemEarnPointRequest(RedeemPointsViewModel model);
        string RedeemRefer(RedeemReferViewModel model);
        string RedeemEarnPointOtherActivity(RedeemPointsViewModel model);

        string AcceptReferRedeemRequest(RedeemPointsViewModel model);
    }
}
