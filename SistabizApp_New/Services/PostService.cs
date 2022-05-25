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

        public List<PostViewModel> GetAllPost()
        {

            var result = _entityDbContext.TblPost
               .Include(s => s.CreatedByNavigation)
            .Include(s => s.TblPostBookMark)
             .Include(s => s.TblPostAttachment)
              .Include(s => s.TblPostFeedback)
            .ToList();



           return result.Select(e => new PostViewModel
            {
                PostId = e.PostId,
                Post = e.Post,
                CreateByName=e.CreatedByNavigation!=null?e.CreatedByNavigation.FirstName+" "+e.CreatedByNavigation.LastName:null,
                CreateByProfile= e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage:null,
                CreateOn=e.CreateOn,
                WebsiteLink=e.WebsiteLink,
                IsBookmark=e.TblPostBookMark.Count>0?true:false,
                TotalLike= e.TblPostFeedback.Where(r=>r.LikeUnlike==1 && r.PostId==e.PostId).Count(),
                TotalUnlike = e.TblPostFeedback.Where(r => r.LikeUnlike == 2 && r.PostId == e.PostId).Count(),
                TotalComment = e.TblPostFeedback.Where(r => r.Commets!=null && r.PostId == e.PostId).Count(),
                lstPostAttachment = e.TblPostAttachment.Count > 0 ? e.TblPostAttachment.Select(r => new PostAttachmentViewModel
                {
                    PostAttachmentId=r.PostAttachmentId,
                    FileName= Constant.livebaseurl + "Post/" + r.FileName
                }).ToList():null,
                lstPostLikeComments = e.TblPostFeedback.Count > 0 ? e.TblPostFeedback.Where(r=>r.PostId==e.PostId).Select(r => new PostLikeCommentsViewModel
                {
                    PostFeedId=r.PostFeedId,
                    LikeUnlike=r.LikeUnlike,
                    Commets=r.Commets,
                    LikeCommentByName= r.Member != null ? r.Member.FirstName + " " + r.Member.LastName : null,
                    LikeCommentByProfile = r.Member != null ? Constant.livebaseurl + "Profiles/" + r.Member.ProfileImage : null,
                   
                }).ToList() : null,
            }).ToList();
            }

       

        public long ManagePost(PostViewModel model)
        {
            TblPost post = new TblPost();
            if (model.PostId > 0)
                post = GetPostById((int)model.PostId);

            post.Post = model.Post;
           
            post.CreatedBy = model.CreatedBy;

            if (model.PostId == 0)
            {
                post.CreateOn = DateTime.Now;
                post.IsDeleted = false;
                _entityDbContext.TblPost.Add(post);
            }

            _entityDbContext.SaveChanges();

            return post.PostId;
        }
        public string UploadPostAttachment(List<TblPostAttachment> attchment)
        {

            _entityDbContext.TblPostAttachment.AddRange(attchment);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }

        public string PostLikeComments(PostLikeCommentsViewModel model)
        {
            TblPostFeedback postfeed = new TblPostFeedback();
            if (model.PostFeedId > 0)
                postfeed = GetPostFeedById((int)model.PostFeedId);
            postfeed.LikeUnlike = model.LikeUnlike;
            postfeed.Commets = model.Commets;
            postfeed.MemberId = model.MemberId;
            postfeed.PostId = model.PostId;
            if (model.PostFeedId == 0)
            {
                postfeed.CreateOn = DateTime.Now;
                postfeed.IsDeleted = false;
                _entityDbContext.TblPostFeedback.Add(postfeed);
            }
            _entityDbContext.SaveChanges();
            return Constant.Success;

        }

        public string PostBookmark(PostBookmarkViewModel model)
        {
            TblPostBookMark bookmark = new TblPostBookMark();
            if (model.BookmarkId > 0)
                bookmark = _entityDbContext.TblPostBookMark.Where(r => r.BookmarkId == model.BookmarkId).FirstOrDefault();
            if(bookmark!=null && model.BookmarkId > 0)
            {
                _entityDbContext.TblPostBookMark.Remove(bookmark);
                _entityDbContext.SaveChanges();
                return "Unbookmark";
            }
            else
            {
                bookmark.MemberId = model.MemberId;
                bookmark.PostId = model.PostId;
                _entityDbContext.TblPostBookMark.Add(bookmark);
                _entityDbContext.SaveChanges();
                return "Bookmark";
            }
              
         

        }

        public string DeletePost(int id)
        {
            var post = GetPostById(id);
            if (post != null)
                _entityDbContext.TblPost.Remove(post);
            _entityDbContext.SaveChanges();
            return "Success";
        }

        public TblPost GetPostById(int id)
        {
            return _entityDbContext.TblPost.Where(e => e.PostId == id).FirstOrDefault();
        }
        public TblPostFeedback GetPostFeedById(int id)
        {
            return _entityDbContext.TblPostFeedback.Where(e => e.PostFeedId == id).FirstOrDefault();
        }
    }
}
