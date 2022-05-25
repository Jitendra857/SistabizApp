using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{

    

    public class GroupViewModel
    {
       
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string GroupDoc { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateByName { get; set; }
        public string CreateByProfile { get; set; }
        public int? Type { get; set; }
        public string Grouptype { get; set; }
        public bool IsSaved { get; set; } = false;
        public long? Category { get; set; }
        public string CategoryName { get; set; }
        public int JoiningTotalMembers { get; set; }

        public bool IsUpdateAttachment { get; set; }
        public List<GroupAttachmentViewModel> lstGroupAttachmentViewModel { get; set; } = new List<GroupAttachmentViewModel>();

        //public GroupJoinMemberViewModel lstJoinMembers { get; set; }
        public List<GroupJoinMemberViewModel> lstGroupJoinMembers { get; set; } = new List<GroupJoinMemberViewModel>();
        public List<IFormFile> Image { get; set; } = new List<IFormFile>();
        public IFormFile GroupIcon { get; set; }
        public string GroupIconPath { get; set; }

        public string Title { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumnetType { get; set; }
        public List<GroupmeetingViewModel> lstGroupMeeting { get; set; } = new List<GroupmeetingViewModel>();
        public List<GroupDiscussionViewModel> lstGroupDiscussion { get; set; } = new List<GroupDiscussionViewModel>();
      

    }
   

    public class GroupAttachmentViewModel
    {
        public long AttachmentId { get; set; }
        public long? GroupId { get; set; }
        public string Attachment { get; set; }
        public string Title { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumnetType { get; set; }
        public bool IsBookmark { get; set; } = false;


    }

    public class GroupJoinMemberViewModel
    {
        public long JoinId { get; set; }
        public long? GroupId { get; set; }
        public string MemberName { get; set; }
        public long? JoinMemberId { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string memberprofile { get; set; }
    }

    public class GroupDiscussionViewModel
    {
        public long DiscussionId { get; set; }
        public long? GroupId { get; set; }
        public long? MessageBy { get; set; }
        public string MemberName { get; set; }
        public string Memberprofile { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Message { get; set; }
    }

    public class GroupBookmarkViewModel
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? CategoryId { get; set; }
        public long? GroupId { get; set; }
    }

    public class GroupAttachmentBookmarkViewModel
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? AttachmentId { get; set; }
       
    }

    public class GroupCategoryViewModel
    {
        public long CategoryId { get; set; }
      public string CategoryName { get; set; }
        public bool IsChecked { get; set; } = false;
    }


    public class GroupFilterViewModel
    {
        public long? MemberId { get; set; }
        public long? CategoryId { get; set; }
        public long? GroupId { get; set; }
        public bool IsSaved { get; set; } = false;
        public int Ordering { get; set; } = 0;
    }
}
