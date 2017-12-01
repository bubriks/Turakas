using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPresentationTier.MessageServiceReference;
using System.ServiceModel;

namespace MVCPresentationTier.Controllers
{
    public class MessageController : Controller, IMessageServiceCallback
    {
        public ActionResult ChatRoom(int? chatId, int? profileId)
        {
            MessageServiceClient client = new MessageServiceClient(new InstanceContext(this));
            if (!chatId.HasValue)
                chatId = 1;
            if (!profileId.HasValue)
                profileId = 1;
            ViewBag.ChatId = "ChatId is " + chatId;
            ViewBag.ProfileId = "ProfileId is " + profileId;
            return View();
        }

        #region For later
        public void AddMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void GetChat(Chat chat)
        {
            throw new NotImplementedException();
        }

        public void GetMessages(Message[] messages)
        {
            throw new NotImplementedException();
        }

        public void GetOnlineProfiles(Profile[] profiles)
        {
            throw new NotImplementedException();
        }

        public void Invite(bool result)
        {
            throw new NotImplementedException();
        }

        public void RemoveMessage(int id)
        {
            throw new NotImplementedException();
        }

        public void Show(bool result)
        {
            throw new NotImplementedException();
        }

        public void WritingMessage()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}