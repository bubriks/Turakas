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
        public ActionResult GetChats(String input, int? profileId)
        {
            if (!profileId.HasValue)
                profileId = 2;
            if (String.IsNullOrWhiteSpace(input))
                input = "";
            ChatServiceClient client = new ChatServiceClient(new InstanceContext(this));
            return View(client.GetChatsByName(input, profileId.Value));
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