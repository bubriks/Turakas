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
            client.Online(1);
            ViewBag.Chats = client.GetChatsByName("", 1);
            ViewBag.SearchBy = "";
            ViewBag.ProfileId = 1;
            return View();
        }

        [HttpPost]
        public ActionResult GetChats(FormCollection collection)
        {
            var cookie = Request.Cookies.Get("aCookie");
            if (cookie != null)
            {
                ChatServiceClient client = new ChatServiceClient(new InstanceContext(this));
                int aCookie = Int32.Parse(cookie.Value);
                client.Online(aCookie);
                ViewBag.Chats = client.GetChatsByName("", aCookie);
                ViewBag.SearchBy = "";
                ViewBag.ProfileId = aCookie;
                return View();
            }
            else
                return Redirect("/Profile/Login");
            //ChatServiceClient client = new ChatServiceClient(new InstanceContext(this));
            //try
            //{
            //    var searchBy = collection["searchBy"];
            //    int profileId = Int32.Parse(collection["profileId"].ToString());
            //    client.Online(profileId);
            //    ViewBag.Chats = client.GetChatsByName(searchBy, profileId);
            //    ViewBag.SearchBy = searchBy;
            //    ViewBag.ProfileId = profileId;
            //}
            //catch (Exception)
            //{
            //    return GetChats();
            //}
            //return View();
        }

        public ActionResult GetChat(int? chatId, int? maxNrOfUsers, String name, int? ownerID, DateTime? time, bool? type)
        {
            Chat chat = new Chat();
            if (!chatId.HasValue)
            {
                chat.ActivityId = 0;
            }
            else
            {
                chat.ActivityId = chatId.Value;
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
                chat.ProfileId = 0;
            }
            else
            {
                chat.ProfileId = ownerID.Value;
            }
            if (!time.HasValue)
            {
                chat.TimeStamp = new DateTime();
            }
            else
            {
                chat.TimeStamp = time.Value;
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
        public void JoinChat(int chatId)
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