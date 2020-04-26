using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.Models
{
    public class MessageModel
    {
        public string Message { set; get; }
        public string Username { set; get; }
        public string Code { set; get; }
        public DateTime date { set; get; }
    }
}