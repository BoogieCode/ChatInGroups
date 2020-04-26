using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.Models
{
    public class UserViewModel
    {
        public string user { set; get; }
        public string password { set; get; }
        public string passwordAgain { set; get; }
    }
}