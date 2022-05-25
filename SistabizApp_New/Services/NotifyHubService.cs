using Microsoft.AspNetCore.SignalR;
using SistabizApp_New.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public class NotifyHubService:Hub<ITtypedHubClient>
    {
    }
}
