using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using System.ServiceModel;
using SignalRChat;

namespace MVCPresentationTier.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult ChatRoom(int? chatId, int? profileId)
        {
            if (!chatId.HasValue)
                chatId = 1;
            if (!profileId.HasValue)
                profileId = 1;
            ViewBag.ChatId = chatId;
            ViewBag.ProfileId = profileId;
            return View();
        }
    }
}