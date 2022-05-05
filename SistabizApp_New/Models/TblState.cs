using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblState
    {
        public long StateId { get; set; }
        public string StateName { get; set; }
        public long? CountryId { get; set; }

        public virtual TblCountry Country { get; set; }
    }
}
