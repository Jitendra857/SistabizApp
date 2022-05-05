using SistabizApp_New.IServices;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService : IBLLService
    {

        public List<CountryViewModel> GetAllCountry()
        {
            return _entityDbContext.TblCountry.Select(e => new CountryViewModel
            {
                CountryId = e.CountryId,
                CountryName = e.CountryName,
            }).ToList();
        }

        public List<StateViewModel> GetAllState()
        {
            return _entityDbContext.TblState.Select(e => new StateViewModel
            {
                StateId = e.StateId,
                StateName = e.StateName,
            }).ToList();
        }

        public List<StateViewModel> GetStateByCountry(int countryid)
        {
            return _entityDbContext.TblState.Where(r=>r.CountryId==countryid).Select(e => new StateViewModel
            {
                StateId = e.StateId,
                StateName = e.StateName,
                CountryId=e.CountryId,
                CountryName=e.Country.CountryName
            }).ToList();
        }
    }
}
