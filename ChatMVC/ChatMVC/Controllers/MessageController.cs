using ChatMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatMVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}