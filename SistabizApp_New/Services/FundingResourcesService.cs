using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService : IBLLService
    {

        public List<FundingCategoryViewModel> GetAllFundingCategory()
        {
            return _entityDbContext.TblFundingCategory.Select(e => new FundingCategoryViewModel
            {
                CategoryId=e.CategoryId,
                CategoryName=e.CategoryName
            }).ToList();
        }
        public List<FundingViewModel> GetAllFundingResource()
        {
            return _entityDbContext.TblFundingResources.Where(r=>r.IsDeleted!=true).Select(e=>new FundingViewModel {

            Title = e.Title,
            Description = e.Description,
            Deadline = e.Deadline,
            CreatedBy = e.CreatedBy,
            CategoryId = e.CategoryId,
            CategoryName=e.Category!=null?e.Category.CategoryName:"",
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            CreateOn = e.CreateOn
            
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
                
               
            return "Success";
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
            return "Success";
        }

    }
}
