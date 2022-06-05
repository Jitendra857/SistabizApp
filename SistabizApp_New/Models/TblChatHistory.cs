using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblChatHistory
    {
        public long ChatId { get; set; }
        public string SenderId { get; set; }
        public string ReachiverId { get; set; }
        public string TrackerId { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
