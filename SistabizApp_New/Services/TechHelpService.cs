using Microsoft.EntityFrameworkCore;
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

        public List<TechHelpViewModel> GetTechhelpDetails(int memberid=0)
        {
            var techehelp = new List<TblTeckHelp>();
            if (memberid == 0)
            {
                techehelp = _entityDbContext.TblTeckHelp.Where(r => r.IsDeleted != true)
                     .Include(s => s.AssignByNavigation)
                       .Include(s => s.AssignToNavigation)
                        .Include(s => s.CreatedByNavigation)
                       .ToList();
            }
            else
            {
                techehelp = _entityDbContext.TblTeckHelp.Where(r => r.IsDeleted != true && r.CreatedBy==memberid)
                   .Include(s => s.AssignByNavigation)
                     .Include(s => s.AssignToNavigation)
                      .Include(s => s.CreatedByNavigation)
                     .ToList();
            }
            return techehelp.Select(e => new TechHelpViewModel
            {
                TechHelpId=e.TechHelpId,
                Title=e.Title,
                Description=e.Description,
                BookingDate=e.BookingDate,
                BookingTime=e.BookingTime,
                AssignBy=e.AssignBy,
                AssignByName=e.AssignByNavigation!=null?e.AssignByNavigation.FirstName+" "+e.AssignByNavigation.LastName:null,
                AssignTo = e.AssignTo,
                AssignToName = e.AssignToNavigation != null ? e.AssignToNavigation.FirstName + " " + e.AssignToNavigation.LastName:null,
                CreatedBy = e.CreatedBy,
                CreatedByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName:null,
                CreatedOn=e.CreatedOn,
                Status=e.Status,
                StatusName=e.Status==1?"Requested":"Assigned",
            }).ToList();
            

        }

        public string ManageTechHelp(TechHelpRequestViewModel model)
        {
            TblTeckHelp techhelp = new TblTeckHelp();
            if(model.TechHelpId>0)
            {
                techhelp = GetTechHelpRecord(model.TechHelpId);
            }
            techhelp.Title = model.Title;
            techhelp.Description = model.Description;
            techhelp.BookingDate = model.BookingDate;
            techhelp.BookingTime = model.BookingTime;
            if (model.TechHelpId == 0)
            {
                techhelp.Status = 1;
                techhelp.CreatedBy = model.CreatedBy;
                techhelp.IsDeleted = false;
                techhelp.CreatedOn = DateTime.Now;
                _entityDbContext.TblTeckHelp.Add(techhelp);

            }
            _entityDbContext.SaveChanges();



            return Constant.Success;
        }

        public string AssignTechHelp(TechHelpAssignedViewModel model)
        {
            TblTeckHelp techhelp = new TblTeckHelp();
            if (model.TechHelpId > 0)
            {
                techhelp = GetTechHelpRecord(model.TechHelpId);
            }
            techhelp.AssignBy = model.AssignBy;
            techhelp.AssignTo = model.AssignTo;

            _entityDbContext.SaveChanges();



            return Constant.Success;
        }


        public TblTeckHelp GetTechHelpRecord(long techhelpid)
        {
            return _entityDbContext.TblTeckHelp.Where(e => e.TechHelpId == techhelpid).FirstOrDefault();
        }
    }
}
