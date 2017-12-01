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
            ViewBag.Chats = client.GetChatsByName("", 1);
            ViewBag.SearchBy = "";
            ViewBag.ProfileId = 1;
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

        public ActionResult GetChat()
        {
            return View(new Chat());
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