using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.Models
{
    public class ParticipantViewModel
    {
        public ParticipantViewModel()
        {
            groups = new List<string>();
            messages = new List<MessageModel>();
        }

        public string code { set; get; }
        public string name { set; get; }

        public List<string> groups;
        public List<MessageModel> messages;

    }
}