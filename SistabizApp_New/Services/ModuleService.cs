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

        public List<ModuleViewModel> GetModuleList()
        {
            return _entityDbContext.TblModule.Select(e => new ModuleViewModel
            {
                ModuleId=e.ModuleId,
                ModuleName=e.ModuleName,
                CreateOn=e.CreateOn
            }).ToList();

        }

        public List<SubscriptionViewModel> GetSubscriptionList()
        {
            return _entityDbContext.TblSubscriptionType.Select(e => new SubscriptionViewModel
            {
                SubscriptionId = e.SubscriptionId,
                SubscriptionName = e.SubscriptionName,
              
            }).ToList();

        }
        public string ManageModule(ModuleViewModel model)
        {
            TblModule module = new TblModule();
            if (model.ModuleId > 0)
                module = GetModulebyId((int)model.ModuleId);
            module.ModuleName = model.ModuleName;
            module.CreatedBy = model.CreatedBy;
            module.CreateOn = DateTime.Now;
            module.IsActive = true;
            module.IsDelete = false;
            if(model.ModuleId==0)
            _entityDbContext.TblModule.Add(module);
            _entityDbContext.SaveChanges();

            return Constant.Success;

        }

        public string AssingModulePermission(ModulePermissionViewModel model)
        {
            TblModulePermission modulepermission = new TblModulePermission();
            if (model.PermissionId > 0)
                modulepermission = GetModulePermissionbyId((int)model.PermissionId);
            modulepermission.SubscriptionType = model.SubscriptionType;
            modulepermission.ModuleId = model.ModuleId;
           
            if (model.PermissionId == 0)
                _entityDbContext.TblModulePermission.Add(modulepermission);
            _entityDbContext.SaveChanges();

            return Constant.Success;

        }



        public string DeleteModule(int id)
        {
            var module = GetModulebyId((int)id);
            if (module != null)
            {
                _entityDbContext.TblModule.Remove(module);
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }

        public TblModule GetModulebyId(int id)
        {
            return _entityDbContext.TblModule.Where(e => e.ModuleId == id).FirstOrDefault();
        }

        public TblModulePermission GetModulePermissionbyId(int id)
        {
            return _entityDbContext.TblModulePermission.Where(e => e.PermissionId == id).FirstOrDefault();
        }
    }

   
}
