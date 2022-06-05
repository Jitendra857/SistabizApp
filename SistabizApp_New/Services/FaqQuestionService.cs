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
        public List<FaqQuestionViewModel> GetFaqQuestionList()
        {
            return _entityDbContext.TblFaqQuestion.Where(r => r.IsDeleted != true).Select(e => new FaqQuestionViewModel
            {

                FaqQuestionId = e.FaqQuestionId,
                Name = e.Name,
                Email = e.Email,
                Message = e.Message,
                CreatedOn = e.CreatedOn,
                MemberId = e.MemberId
            }).ToList();

        }



        public string ManageFaqQuestion(FaqQuestionViewModel model)
        {
            TblFaqQuestion fundingresource = new TblFaqQuestion();
            if (model.FaqQuestionId > 0)
                fundingresource = GetFaqQuestionById((int)model.FaqQuestionId);

            fundingresource.Name = model.Name;
            fundingresource.Email = model.Email;
            fundingresource.Message = model.Message;
          // fundingresource.CreatedOn = model.CreatedOn;
            fundingresource.MemberId = model.MemberId;
            fundingresource.IsDeleted = false;
            fundingresource.CreatedOn = DateTime.Now;
            if (model.FaqQuestionId == 0)
                _entityDbContext.TblFaqQuestion.Add(fundingresource);
            _entityDbContext.SaveChanges();


            return Constant.Success;
        }


        public string DeleteFaqQuestion(int fundingid)
        {
            var getfundingresource = GetFundingResourceById(fundingid);
            if (getfundingresource != null)
            {
                getfundingresource.IsDeleted = true;
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }

        public TblFaqQuestion GetFaqQuestionById(int questionid)
        {
            return _entityDbContext.TblFaqQuestion.Where(e => e.FaqQuestionId == questionid).FirstOrDefault();
        }
    }
}
