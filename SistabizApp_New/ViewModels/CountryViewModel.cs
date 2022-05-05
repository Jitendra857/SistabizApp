using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class CountryViewModel
    {
        public long CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class StateViewModel
    {
        public long StateId { get; set; }
        public string StateName { get; set; }

        public string CountryName { get; set; }
        public long? CountryId { get; set; }
    }
}
