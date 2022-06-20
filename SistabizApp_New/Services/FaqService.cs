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
        public List<FaqCategoryViewModel> GetAllFaqCategory()
        {
            return _entityDbContext.TblFaqCategory.Select(e => new FaqCategoryViewModel
            {
                FaqCategoryId=e.FaqCategoryId,
                CategoryName=e.CategoryName
            }).ToList();
        }

        public List<FaqViewModel> GetAllFaq(string search=null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _entityDbContext.TblFaq.Where(r => r.IsDeleted != true && r.Question.Contains(search)).Select(e => new FaqViewModel
                {
                    QuestionId = e.QuestionId,
                    Question = e.Question,
                    Answer = e.Answer,
                    FaqCategoryId = e.FaqCategoryId,
                    CategoryName = e.FaqCategory.CategoryName,
                    CreatedBy=e.CreatedBy



                }).ToList();
            }
            else
            {
                return _entityDbContext.TblFaq.Where(r => r.IsDeleted != true).Select(e => new FaqViewModel
                {
                    QuestionId = e.QuestionId,
                    Question = e.Question,
                    Answer = e.Answer,
                    FaqCategoryId = e.FaqCategoryId,
                    CategoryName = e.FaqCategory.CategoryName


                }).ToList();
            }
           
        }
        public List<FaqCategoryViewModel> GetAllFaqByCategory()
        {
            var result= _entityDbContext.TblFaqCategory.Select(e => new FaqCategoryViewModel
            {
                FaqCategoryId = e.FaqCategoryId,
                CategoryName = e.CategoryName,
                lstfaq=e.TblFaq.Count>0?e.TblFaq.Where(r => r.IsDeleted != true ).Select(e => new FaqViewModel
                {
                    QuestionId = e.QuestionId,
                    Question = e.Question,
                    Answer = e.Answer,
                    FaqCategoryId = e.FaqCategoryId,
                    CategoryName = e.FaqCategory.CategoryName

                }).ToList():null
        }).ToList();

            return result;

            //return _entityDbContext.TblFaq.Where(r=>r.IsDeleted!=true && r.FaqCategoryId==categoryid).Select(e => new FaqViewModel
            //{
            //    QuestionId = e.QuestionId,
            //    Question = e.Question,
            //    Answer = e.Answer,
            //    FaqCategoryId = e.FaqCategoryId,
            //    CategoryName = e.FaqCategory.CategoryName


            //}).ToList();
        }

        public string ManageFaq(FaqViewModel model)
        {
            TblFaq faq = new TblFaq();
            if (model.QuestionId > 0)
                faq = GetFeqById((int)model.QuestionId);

            faq.Question = model.Question;
            faq.Answer = model.Answer;
            faq.FaqCategoryId = model.FaqCategoryId;
            faq.CreatedBy = model.CreatedBy;
            faq.CreatedOn = DateTime.Now;
            faq.IsDeleted =false;

            if (model.QuestionId == 0)
                _entityDbContext.TblFaq.Add(faq);

            _entityDbContext.SaveChanges();

            return Constant.Success;
        }

        public string DeleteFaq(int id)
        {
            var faq = GetFeqById(id);
            if (faq != null)
                _entityDbContext.TblFaq.Remove(faq);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }

        public TblFaq GetFeqById(int id)
        {
            return _entityDbContext.TblFaq.Where(e => e.QuestionId == id).First();
        }
    }
}
