using MVCPresentationTier.ChatServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationTier.Controllers
{
    public class ChatController : Controller, IChatServiceCallback
    {
        public ActionResult GetChats()
        {
            ChatServiceClient client = new ChatServiceClient(new InstanceContext(this));
            ViewBag.Chats = client.GetChatsByName("", 0);
            ViewBag.SearchBy = "";
            ViewBag.ProfileId = 0;
            return View();
        }

        [HttpPost]
        public ActionResult GetChats(String input, int? profileId)
        {
            if (!profileId.HasValue)
                profileId = 1;
            ChatServiceClient client = new ChatServiceClient(new InstanceContext(this));
            ViewBag.Chats = client.GetChatsByName(input, profileId.Value);
            ViewBag.SearchBy = input;
            ViewBag.ProfileId = profileId.Value;
            return View();
        }

        public ActionResult GetChat(int? chatId, int? maxNrOfUsers, String name, int? ownerID, DateTime? time, bool? type)
        {
            Chat chat = new Chat();
            if (!chatId.HasValue)
            {
                chat.Id = 0;
            }
            else
            {
                chat.Id = chatId.Value;
            }
            if (!maxNrOfUsers.HasValue)
            {
                chat.MaxNrOfUsers = 0;
            }
            else
            {
                chat.MaxNrOfUsers = maxNrOfUsers.Value;
            }
            chat.Name = name;
            if (!ownerID.HasValue)
            {
                chat.OwnerID = 0;
            }
            else
            {
                chat.OwnerID = ownerID.Value;
            }
            if (!time.HasValue)
            {
                chat.Time = new DateTime();
            }
            else
            {
                chat.Time = time.Value;
            }
            if (!type.HasValue)
            {
                chat.Type = true;
            }
            else
            {
                chat.Type = type.Value;
            }
            return View(chat);
        }

        #region For later
        public void joinChat(int chatId)
        {
            throw new NotImplementedException();
        }

        public void Notification(Chat chat)
        {
            throw new NotImplementedException();
        }

        public void Refreshed()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}