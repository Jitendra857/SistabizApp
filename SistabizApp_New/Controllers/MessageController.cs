using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SistabizApp_New.Hubs;
using SistabizApp_New.Interface;
using SistabizApp_New.IServices;
using SistabizApp_New.Services;
using SistabizApp_New.ViewModels;
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
        private readonly IHubContext<NotificationHub> _notificationUserHubContext;
        private readonly IUserConnectionManager _userConnectionManager;

        public MessageController( IHubContext<NotificationHub> notificationUserHubContext, IUserConnectionManager userConnectionManager)
        {
            
            _notificationUserHubContext = notificationUserHubContext;
            _userConnectionManager = userConnectionManager;
        }

        [HttpPost]
        [Route("sendmessage")]
        public async Task<ActionResult> SendToSpecificUser(MessageViewModel model)
        {
            var connections = _userConnectionManager.GetUserConnections(model.UserId);
            if (connections != null && connections.Count > 0)
            {
                foreach (var connectionId in connections)
                {
                    await _notificationUserHubContext.Clients.Client(connectionId).SendAsync("sendToUser", model.Meesage);
                }
            }
            return Ok();
        }

        //[HttpGet]
        //[Route("getconnection")]
        //public async Task<ActionResult> GetConnection()
        //{
        //    var connections = _userConnectionManager.GetUserConnections();
        //    if (connections != null && connections.Count > 0)
        //    {
        //        foreach (var connectionId in connections)
        //        {
        //            await _notificationUserHubContext.Clients.Client(connectionId).SendAsync("sendToUser", model.Meesage);
        //        }
        //    }
        //    return Ok();
        }
        // private IHubContext<NotifyHubService, ITtypedHubClient> _hubContext;

        //public async Task SendMessage(ChatMessage message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", message);
        //}
    //}
}
