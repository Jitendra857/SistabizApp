using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SistabizApp_New.IServices;
using SistabizApp_New.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private IHubContext<NotifyHubService, ITtypedHubClient> _hubContext;

        public MessageController()
        {

        }
    }
}
