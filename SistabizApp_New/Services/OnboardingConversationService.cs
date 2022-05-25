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

        public List<QuestionViewModel> GetAllConversationQuestion()
        {
            return _entityDbContext.TblOnboardingConversation.Select(e => new QuestionViewModel
            {
                QuestionId = e.QuestionId,
                Question = e.Question
            }).ToList();
        }

        public List<QuestionViewModel> GetAllQuestionAnswer()
        {
            return _entityDbContext.TblOnboardingConversation.Select(e => new QuestionViewModel
            {
                QuestionId = e.QuestionId,
                Question = e.Question,
                lstQuestionANswer = e.TblConversationAnswer.Count > 0 ? e.TblConversationAnswer.Select(r => new QuestionAnswerViewModel
                {
                    AnswerId=r.ConversationAnswerId,
                    Answer=r.Answer
                }).ToList():null
            }).ToList();
        }

        public string ManageQuestionAnswer(List<QuestionAnswerViewModel> model)
        {
            List<TblConversationQuestionAnswer> questionanswer = new List<TblConversationQuestionAnswer>();
            foreach(var item in model)
            {
                questionanswer.Add(new TblConversationQuestionAnswer { QuestionId = item.QuestionId, AnswerId = item.AnswerId, MemberId = item.MemberId,CreatedOn=DateTime.Now,IsDeleted=false });
            }
            _entityDbContext.TblConversationQuestionAnswer.AddRange(questionanswer);
            _entityDbContext.SaveChanges();

            return Constant.Success;
        }
    }
}
