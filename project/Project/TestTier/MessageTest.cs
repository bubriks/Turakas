using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier;
using DataTier;
using System.Collections.Generic;

namespace TestTier
{
    [TestClass]
    public class MessageTest
    {
        private MessageController controller = null;
        private ChatController chatController = null;
        private int profileId = 12;

        public MessageTest()
        {
            controller = new MessageController();
            chatController = new ChatController();
        }

        #region Create message
        [TestMethod]
        public void CreateMessageWorking()
        {
            List<Chat> chats = chatController.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            Assert.AreNotEqual(null, controller.CreateMessage(profileId, "test", chat.Id));
        }

        [TestMethod]
        public void CreateMessageWrongProfileId()
        {
            List<Chat> chats = chatController.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            Assert.AreEqual(null, controller.CreateMessage(0, "test", chat.Id));
        }

        [TestMethod]
        public void CreateMessageWrongChatId()
        {
            Assert.AreEqual(null, controller.CreateMessage(profileId, "test", 0));
        }

        [TestMethod]
        public void CreateMessageEmptyMessage()
        {
            List<Chat> chats = chatController.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            Assert.AreEqual(null, controller.CreateMessage(profileId, "", chat.Id));
        }
        #endregion

        #region Get messages
        [TestMethod]
        public void GetMessagesWorking()
        {
            List<Chat> chats = chatController.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.CreateMessage(profileId, "test", chat.Id);
            Assert.AreNotEqual(0, controller.GetMessages(chat.Id).Count);
        }

        [TestMethod]
        public void GetMessagesWrongChatId()
        {
            Assert.AreEqual(0, controller.GetMessages(0).Count);
        }
        #endregion

        #region Delete message
        [TestMethod]
        public void DeleteMessagesWorking()
        {
            List<Chat> chats = chatController.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            Message message = controller.CreateMessage(profileId, "test", chat.Id);
            Assert.AreEqual(true, controller.DeleteMessage(profileId, message.Id));
        }

        [TestMethod]
        public void DeleteMessagesWrongMessageId()
        {
            Assert.AreEqual(false, controller.DeleteMessage(profileId, 0));
        }

        [TestMethod]
        public void DeleteMessagesWrongProfileId()
        {
            List<Chat> chats = chatController.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            Message message = controller.CreateMessage(profileId, "test", chat.Id);
            Assert.AreEqual(false, controller.DeleteMessage(0, message.Id));
        }
        #endregion
    }
}
