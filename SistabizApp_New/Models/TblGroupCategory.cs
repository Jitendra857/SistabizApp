using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroupCategory
    {
        public TblGroupCategory()
        {
            TblGroup = new HashSet<TblGroup>();
            TblGroupBookmarks = new HashSet<TblGroupBookmarks>();
        }

        public long GroupCategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TblGroup> TblGroup { get; set; }
        public virtual ICollection<TblGroupBookmarks> TblGroupBookmarks { get; set; }
    }
}
