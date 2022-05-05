using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblCountry
    {
        public TblCountry()
        {
            TblState = new HashSet<TblState>();
        }

        public long CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<TblState> TblState { get; set; }
    }
}
