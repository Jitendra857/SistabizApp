using SistabizApp_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService
    {

      
        private readonly SistabizAppContext _entityDbContext;
        public BLLService(SistabizAppContext dbContext)
        {
            _entityDbContext = dbContext;
            
        }
    }
}
