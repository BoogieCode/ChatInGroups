using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatMVC.Hubs
{
    public class MyHub : Hub
    {
        
        public override Task OnConnected()
        {
           _=new HelpMethods.ChatTracker();

            signalConnectionId(this.Context.ConnectionId);
            return base.OnConnected();
        }

        private void signalConnectionId(string signalConnectionId)
        {
            Clients.Client(signalConnectionId).signalConnectionId(signalConnectionId);
        }

        public void Send(string groupname,string user,string message)
        {
            // Call the addMessage method on all clients            
            Clients.Group(groupname).addMessage(user, message);

            HelpMethods.ChatTracker.addMessageInRoom(message,user,groupname);
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.Add(Context.ConnectionId, roomName);
            Clients.Group(roomName).addChatMessage(Context.User.Identity.Name + " joined.");
        }


        public Task LeaveRoom(string roomName)
        {
            return Groups.Remove(Context.ConnectionId, roomName);
        }
    }
}