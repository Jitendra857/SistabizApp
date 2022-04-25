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
        public List<FaqCategoryViewModel> GetAllFaqCategory()
        {
            return _entityDbContext.TblFaqCategory.Select(e => new FaqCategoryViewModel
            {
                FaqCategoryId=e.FaqCategoryId,
                CategoryName=e.CategoryName
            }).ToList();
        }

        public List<FaqViewModel> GetAllFaq()
        {
            return _entityDbContext.TblFaq.Select(e => new FaqViewModel
            {
                QuestionId=e.QuestionId,
                Question=e.Question,
                Answer=e.Answer,
                FaqCategoryId=e.FaqCategoryId,
                CategoryName=e.FaqCategory.CategoryName
                
                
            }).ToList();
        }

        public string ManageFaq(FaqViewModel model)
        {
            TblFaq faq = new TblFaq();
            if (model.QuestionId > 0)
                faq = GetFeqById((int)model.QuestionId);

            faq.Question = model.Question;
            faq.Answer = model.Answer;
            faq.FaqCategoryId = model.FaqCategoryId;

                if(model.QuestionId == 0)
                _entityDbContext.TblFaq.Add(faq);

            _entityDbContext.SaveChanges();

            return "Success";
        }

        public string DeleteFaq(int id)
        {
            var faq = GetFeqById(id);
            if (faq != null)
                _entityDbContext.TblFaq.Remove(faq);
            _entityDbContext.SaveChanges();
            return "Success";
        }

        public TblFaq GetFeqById(int id)
        {
            return _entityDbContext.TblFaq.Where(e => e.QuestionId == id).First();
        }
    }
}
