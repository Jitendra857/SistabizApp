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
            return _entityDbContext.TblPost.Select(e => new PostViewModel
            {
                PostId = e.PostId,
                Post = e.Post,
                lstPostAttachment = e.TblPostAttachment.Count > 0 ? e.TblPostAttachment.Select(r => new PostAttachmentViewModel
                {
                    PostAttachmentId=r.PostAttachmentId,
                    FileName=r.FileName
                }).ToList():null,
                lstPostLikeComments = e.TblPostFeedback.Count > 0 ? e.TblPostFeedback.Select(r => new PostLikeCommentsViewModel
                {
                    PostFeedId=r.PostFeedId,
                    LikeUnlike=r.LikeUnlike,
                    Commets=r.Commets,
                    
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
            return "Success";

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
