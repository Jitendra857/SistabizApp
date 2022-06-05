using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class BadgesViewModel
    {
        public long BadgesId { get; set; } = 0;
        public string BadgesName { get; set; }
      
        public long? CreatedBy { get; set; }
        public IFormFile Image { get; set; }
        public string ImgaeUrl { get; set; }

    }

    public class BadgesAssignViewMidel
    {
        public long BadgesAssignId { get; set; }
        public long? BadgesId { get; set; }
        public long? MemberId { get; set; }
       
    }
}
