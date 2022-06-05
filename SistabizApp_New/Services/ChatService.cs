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
        public List<ChatViewModel> GetChatHistory()
        {
            return _entityDbContext.TblChatHistory.Select(e => new ChatViewModel
            {
                ChatId=e.ChatId,
                SenderId = e.SenderId,
                ReachiverId = e.ReachiverId,
                TrackerId = e.TrackerId,
                Message = e.Message,
                CteatedOn=e.CreatedOn
            }).OrderByDescending(r=>r.ChatId).ToList();
        }

        public string ManageChat(ChatViewModel model)
        {
            TblChatHistory chat = new TblChatHistory();
            chat.SenderId = model.SenderId;
            chat.ReachiverId = model.ReachiverId;
            chat.TrackerId = model.TrackerId;
            chat.Message = model.Message;
            chat.CreatedOn = DateTime.Now;
            _entityDbContext.TblChatHistory.Add(chat);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }
    }


}
