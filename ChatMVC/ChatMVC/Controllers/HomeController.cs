using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatMVC.Db;
using ChatMVC.HelpMethods;
using ChatMVC.Models;

namespace ChatMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Chat(string code)
        {
            
            ChatDb db = new ChatDb();
            
            if (code == null)
            {
                code = HelpMethods.HelpMethods.GroupCodeGenerator();
            }
            else if(db.Rooms.Where(m => m.RoomCode == code).FirstOrDefault() == null)
            {
                return View();
            }
            GroupViewModel model = new GroupViewModel();// HelpMethods.RoomJoiner.joinRoom(code,User.Identity.Name,participants);

            return View(model);
        }

        [Authorize]
        public ActionResult MyChat(string code,string name)
        {

            ChatDb db = new ChatDb();



            ParticipantViewModel viewModel = new ParticipantViewModel(){
                code=code,
                name=name
            };

            int Id = db.Users.Where(m => m.Username == User.Identity.Name).FirstOrDefault().UserId;
            List<Participant> participants = db.Participants.Where(m => m.Id == Id).ToList();
            foreach(var p in participants)
            {
                viewModel.groups.Add(p.RoomCode);
            }

            List<MessageModel> messages = db.Messages.Where(m => m.Roomcode == code).Select(m=>new MessageModel { Username=m.Username,Message=m.Message1}).ToList();
            viewModel.messages = messages;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult CreateChat()
        {

           ParticipantViewModel model = HelpMethods.RoomJoiner.createRoom(User.Identity.Name);

            return RedirectToAction("MyChat",new { code=model.code,name=model.name});
        }


        [HttpGet]
        public ActionResult JoinChat(string code)
        {
            return View();
        }

        [HttpPost]
        public ActionResult JoinChat(CodeViewModel viewModel)
        {
            ParticipantViewModel model = HelpMethods.RoomJoiner.joinRoom(viewModel.code, User.Identity.Name);


            return RedirectToAction("MyChat", new { code = model.code, name = model.name });
        }
    }
}