using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SocialNetwork.Hubs
{
    [HubName("msg")]
    [Authorize]
    public class MessageHub : Hub
    {
        public override Task OnConnected()
        {
            var email = Context.User.Identity.Name;
            Groups.Add(Context.ConnectionId, email);
            
            
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var email = Context.User.Identity.Name;
            Groups.Remove(Context.ConnectionId, email);


            return base.OnDisconnected(stopCalled);
        }
    }
}