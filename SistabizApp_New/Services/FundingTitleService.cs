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
        public FundingTitleViewModel GetFundingTitleDetails()
        {
            return _entityDbContext.TblFundingSection.Select(e => new FundingTitleViewModel
            {
                FundingSectionId = e.FundingSectionId,
                Title=e.Title,
                Description=e.Description,
                CreateOn=e.CreateOn,
                FundingTitlePath = Constant.livebaseurl + "GroupIcon/" + e.FileUrl
            }).FirstOrDefault();
        }
        public string ManageFundingTitle(FundingTitleViewModel model)
        {
            TblFundingSection fundingtitle = new TblFundingSection();
            if (model.FundingSectionId > 0)
            {
                fundingtitle = GetFundingSection((int)model.FundingSectionId);
            }
            fundingtitle.Title = model.Title;
            fundingtitle.Description = model.Description;
            fundingtitle.FileUrl = model.FundingTitlePath;
            fundingtitle.CreateOn = DateTime.Now;
            fundingtitle.IsDeleted = false;
            if (model.FundingSectionId == 0)
                _entityDbContext.TblFundingSection.Add(fundingtitle);
            _entityDbContext.SaveChanges();

            return Constant.Success;
        }

        public string DeleteFundingTitle(int id)
        {
            var result= GetFundingSection(id);
            if(result!=null)
            {
                _entityDbContext.TblFundingSection.Remove(result);
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }

        public TblFundingSection GetFundingSection(int id)
        {
            return _entityDbContext.TblFundingSection.Where(e => e.FundingSectionId == id).FirstOrDefault();
        }
    }
}
