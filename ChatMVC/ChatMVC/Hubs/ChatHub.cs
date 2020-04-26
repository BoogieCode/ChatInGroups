using ChatMVC.Db;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatMVC.Hubs
{
    public class ChatHub : Hub
    {
        
    public void Send( string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

    }

}
