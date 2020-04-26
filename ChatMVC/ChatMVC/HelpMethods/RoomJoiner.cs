using ChatMVC.Db;
using ChatMVC.Hubs;
using ChatMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.HelpMethods
{
    public static class RoomJoiner
    {
        public static ParticipantViewModel createRoom(string username)
        {
            //Initialize group
            GroupViewModel group = new GroupViewModel();

            //Add known informations
            group.code = HelpMethods.GroupCodeGenerator();

            group.currentUsername = username;

            //Create a room in database
            using (var db = new ChatDb())
            {
                var room = db.Rooms.Where(m => m.RoomCode == group.code).FirstOrDefault();



                var newRoom = new Room
                {
                    RoomCode = group.code,
                    Admin = username,
                    CreatedAt = DateTime.Now
                };
                db.Rooms.Add(newRoom);
                db.SaveChanges();

                group.admin = newRoom.Admin;
                group.createdAt = newRoom.CreatedAt;
                group.participants.Add(username);
            }

            ParticipantViewModel model = new ParticipantViewModel
            {
                code = group.code,
                name = group.admin
            };

            return model;
        }

        public static ParticipantViewModel joinRoom(string code,string name)
        {
            ParticipantViewModel model = new ParticipantViewModel
            {
                code = code,
                name = name
            };
            return (model);
        }

    }
}