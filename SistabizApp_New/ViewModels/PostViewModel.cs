using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class PostViewModel
    {
        public long PostId { get; set; }
        public string Post { get; set; }
        public DateTime? CreateOn { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateByName { get; set; }
        public string CreateByProfile { get; set; }
        public string WebsiteLink { get; set; }
        public bool IsBookmark { get; set; } = false;
        public int TotalLike { get; set; } = 0;
        public int TotalUnlike { get; set; } = 0;
        public int TotalComment { get; set; } = 0;
        public bool IsUpdateAttachment { get; set; }
        public List<IFormFile> Image { get; set; } = new List<IFormFile>();

        public List<PostAttachmentViewModel> lstPostAttachment { get; set; } = new List<PostAttachmentViewModel>();
        public List<PostLikeCommentsViewModel> lstPostLikeComments { get; set; } = new List<PostLikeCommentsViewModel>();
    }

    public class PostBookmarkViewModel
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? PostId { get; set; }
    }
    public class PostAttachmentViewModel
    {
        public long PostAttachmentId { get; set; }
        public string FileName { get; set; }

    }

    public class PostLikeCommentsViewModel
    {
        public long PostFeedId { get; set; }
        public int? LikeUnlike { get; set; }
        public string Commets { get; set; }
        public long? MemberId { get; set; }
        public long? PostId { get; set; }
        public string LikeCommentByName { get; set; }
        public string LikeCommentByProfile { get; set; }
        public DateTime? CreateOn { get; set; }

    }
}
