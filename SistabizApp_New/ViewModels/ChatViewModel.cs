using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class ChatViewModel
    {

        public long ChatId { get; set; }
        public string SenderId { get; set; }
        public string ReachiverId { get; set; }
        public string TrackerId { get; set; }
        public string Message { get; set; }
        public DateTime? CteatedOn { get; set; }
    }
}
