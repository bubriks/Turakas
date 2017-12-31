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
        public ActionResult ChatRoom(int? chatId)
        {
            if (chatId.HasValue)
            {
                var cookie = Request.Cookies.Get("aCookie");
                if (cookie != null)
                {
                    ViewBag.ChatId = chatId;
                    ViewBag.ProfileId = Int32.Parse(cookie.Value);
                    return View();
                }
                else
                {
                    return Redirect("/Profile/Login");
                }
            }
            else
            {
                return Redirect("/Chat/GetChats");
            }
        }
    }
}