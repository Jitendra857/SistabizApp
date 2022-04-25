using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class PostViewModel
    {
        public long PostId { get; set; }
        public string Post { get; set; }
        public DateTime? CreateOn { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
