using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService : IBLLService
    {

        public List<FundingCategoryViewModel> GetAllFundingCategory()
        {
            return _entityDbContext.TblFundingCategory.Select(e => new FundingCategoryViewModel
            {
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName
            }).ToList();
        }
        public List<FundingViewModel> GetAllFundingResource()
        {
            return _entityDbContext.TblFundingResources.Where(r => r.IsDeleted != true).Select(e => new FundingViewModel
            {

                FundingId = e.FundingId,
                Title = e.Title,
                Description = e.Description,
                Deadline = e.Deadline,
                CreatedBy = e.CreatedBy,
                CategoryId = e.CategoryId,
                CategoryName = e.Category != null ? e.Category.CategoryName : "",
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                CreateOn = e.CreateOn,
                IsBookmark = e.TblFundingBookmark.Count > 0 ? true : false

            }).ToList();
        }


        public List<FundingViewModel> SearchFundingResource(string search)
        {
            return _entityDbContext.TblFundingResources.Where(r => r.IsDeleted != true && r.Title.Contains(search)).Select(e => new FundingViewModel
            {

                FundingId = e.FundingId,
                Title = e.Title,
                Description = e.Description,
                Deadline = e.Deadline,
                CreatedBy = e.CreatedBy,
                CategoryId = e.CategoryId,
                CategoryName = e.Category != null ? e.Category.CategoryName : "",
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                CreateOn = e.CreateOn,
                IsBookmark = e.TblFundingBookmark.Count > 0 ? true : false

            }).ToList();
        }
        public FundingViewModel GetAllFundingResourceById(int id)
        {
            return _entityDbContext.TblFundingResources.Where(r => r.IsDeleted != true && r.FundingId == id).Select(e => new FundingViewModel
            {
                FundingId = e.FundingId,
                Title = e.Title,
                Description = e.Description,
                Deadline = e.Deadline,
                CreatedBy = e.CreatedBy,
                CategoryId = e.CategoryId,
                CategoryName = e.Category != null ? e.Category.CategoryName : "",
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                CreateOn = e.CreateOn,
                IsBookmark = e.TblFundingBookmark.Count > 0 ? true : false

            }).FirstOrDefault();
        }
        public List<FundingViewModel> GetAllFundingResourceByCategory(int categoryid)
        {

            return _entityDbContext.TblFundingResources.Where(r => r.IsDeleted != true && r.CategoryId == categoryid).Select(e => new FundingViewModel
            {
                FundingId = e.FundingId,
                Title = e.Title,
                Description = e.Description,
                Deadline = e.Deadline,
                CreatedBy = e.CreatedBy,
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                CategoryId = e.CategoryId,
                CategoryName = e.Category != null ? e.Category.CategoryName : "",
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                CreateOn = e.CreateOn,
                IsBookmark = e.TblFundingBookmark.Count > 0 ? true : false

            }).ToList();
        }
        public List<FundingViewModel> GetAllFundingResourceByDate(string date)
        {
            var createdon = Convert.ToDateTime(date);
            return _entityDbContext.TblFundingResources.Where(r => r.IsDeleted != true && r.CreateOn == createdon).Select(e => new FundingViewModel
            {
                FundingId = e.FundingId,
                Title = e.Title,
                Description = e.Description,
                Deadline = e.Deadline,
                CreatedBy = e.CreatedBy,
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                CategoryId = e.CategoryId,
                CategoryName = e.Category != null ? e.Category.CategoryName : "",
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                CreateOn = e.CreateOn,
                IsBookmark = e.TblFundingBookmark.Count > 0 ? true : false

            }).ToList();
        }
        public string ManageFundingResources(FundingViewModel model)
        {
            TblFundingResources fundingresource = new TblFundingResources();
            if (model.FundingId > 0)
                fundingresource = GetFundingResourceById((int)model.FundingId);


            fundingresource.Title = model.Title;
            fundingresource.Description = model.Description;
            fundingresource.Deadline = model.Deadline;
            fundingresource.CreatedBy = model.CreatedBy;
            fundingresource.CategoryId = model.CategoryId;
            fundingresource.StartDate = model.StartDate;
            fundingresource.EndDate = model.EndDate;
            fundingresource.CreateOn = DateTime.Now;
            fundingresource.IsDeleted = false;
            if (model.FundingId == 0)
                _entityDbContext.TblFundingResources.Add(fundingresource);
            _entityDbContext.SaveChanges();


            return Constant.Success;
        }

        public string FundingResourceBookmark(FundingBookmarkViewModel model)
        {
            TblFundingBookmark bookmark = new TblFundingBookmark();
            if (model.BookmarkId > 0)
            {
                var result = _entityDbContext.TblFundingBookmark.Where(e => e.BookmarkId == model.BookmarkId).FirstOrDefault();

                if (result != null)
                {
                    _entityDbContext.TblFundingBookmark.Remove(result);
                    _entityDbContext.SaveChanges();
                    return "Unbookmark";
                }
            }
            else
            {

                bookmark.MemberId = model.MemberId;
                bookmark.CategoryId = model.CategoryId;
                bookmark.FundingId = model.FundingId;
                _entityDbContext.TblFundingBookmark.Add(bookmark);
                _entityDbContext.SaveChanges();
                return "bookmark";
            }
            return Constant.Success;
        }
        public TblFundingResources GetFundingResourceById(int fundingid)
        {
            return _entityDbContext.TblFundingResources.Where(e => e.FundingId == fundingid).FirstOrDefault();
        }

        public string DeleteFundingResource(int fundingid)
        {
            var getfundingresource = GetFundingResourceById(fundingid);
            if (getfundingresource != null)
            {
                getfundingresource.IsDeleted = true;
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }

    }
}
