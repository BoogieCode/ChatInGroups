using ChatMVC.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.Models
{
    public class GroupViewModel
    {
        public GroupViewModel()
        {
            participants = new List<string>();
        }
        public string code { set; get; }
        public string admin { set; get; }
        public string currentUsername { set; get; }
        public List<string> participants { set; get; }       
        public DateTime createdAt { get; set; }

    }
}