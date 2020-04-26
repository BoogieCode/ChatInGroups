using ChatMVC.Db;
using ChatMVC.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace ChatMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid && model.password == model.passwordAgain)
            {
                using (var db = new ChatDb())
                {
                    if (db.Users.Where(m => m.Username == model.user).FirstOrDefault() == null)
                    {
                        db.Users.Add(new User
                        {
                            Username = model.user,
                            HashPassword = Crypto.HashPassword(model.password)
                        });

                        db.SaveChanges();

                        return RedirectToAction("Index", "Message", new { message="Successfully Registered"});
                    }
                }
                
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var username = model.user;
                using (var db = new ChatDb())
                {
                    var user = db.Users.FirstOrDefault(p => p.Username == model.user);
                    if (user != null && Crypto.VerifyHashedPassword(user.HashPassword, model.password))
                    {
                        FormsAuthentication.SetAuthCookie(user.Username, true);
                        string s = User.Identity.Name;
                        return RedirectToAction("Contact","Home");
                    }
                }

            }

            return View();
        }
    }
}