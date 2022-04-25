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
                Post = e.Post
            }).ToList();
        }

       

        public string ManagePost(PostViewModel model)
        {
            TblPost post = new TblPost();
            if (model.PostId > 0)
                post = GetPostById((int)model.PostId);

            post.Post = model.Post;
            post.CreateOn = DateTime.Now;
            post.IsDeleted = false;

            if (model.PostId == 0)
                _entityDbContext.TblPost.Add(post);

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
    }
}
