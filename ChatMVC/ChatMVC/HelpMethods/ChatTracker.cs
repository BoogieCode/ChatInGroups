using ChatMVC.Db;
using ChatMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.HelpMethods
{

    public class ChatTracker
    {

        public static ChatDb Db;
        public ChatTracker()
        {
            Db = new ChatDb();
        }

        public static void addMessageInRoom(string Message, string Username, string Code)
        {
            Db.Messages.Add(new Db.Message
            {
                Message1 = Message,
                Roomcode = Code,
                Username = Username,
                SendDate = DateTime.Now
            });
            Db.SaveChanges();
        }
    }
}
