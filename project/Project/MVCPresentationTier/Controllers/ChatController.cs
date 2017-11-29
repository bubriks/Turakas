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
        public ActionResult Index()
        {
            ChatServiceClient client = new ChatServiceClient(new InstanceContext(this));
            return View(client.GetChatsByName("", 1));
        }

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
    }
}