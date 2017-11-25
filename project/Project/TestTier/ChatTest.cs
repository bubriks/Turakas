using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTier;
using BusinessTier;

namespace TestTier
{
    [TestClass]
    public class ChatTest
    {
        private ChatController controller = null;
        private int profileId = 1, profileId1 = 2;

        public ChatTest()
        {
            controller = new ChatController();
        }

        [TestMethod]
        public void CreateChatWorking()
        {
            Chat chat = new Chat
            {
                MaxNrOfUsers = 2,
                Name = "testChat",
                OwnerID = profileId,
                Type = true
            };
            Assert.AreNotEqual(null, controller.SaveChat(profileId, chat));
        }

        [TestMethod]
        public void CreateChatWithWrongDetails()
        {
            Chat chat = new Chat
            {
                MaxNrOfUsers = 2,
                Name = "testChat",
                OwnerID = 0,
                Type = true
            };
            Assert.AreEqual(null, controller.SaveChat(profileId, chat));
        }

        [TestMethod]
        public void UpdateChatWorking()
        {
            Chat chat = controller.GetChatsByName("iiasdfhc zkdbefasbcgvAasda", profileId)[0];
            chat.Type = true;
            Assert.AreNotEqual(null, controller.SaveChat(profileId, chat));
        }

        [TestMethod]
        public void UpdateNotYourChatDetails()
        {
            Chat chat = controller.GetChatsByName("", profileId)[0];
            chat.Type = true;
            Assert.AreEqual(null, controller.SaveChat(0, chat));
        }

        [TestMethod]
        public void UpdateChatWrongDetails()
        {
            Chat chat = new Chat
            {
                MaxNrOfUsers = 2,
                Name = "testChat",
                Id = 0,
                Type = true
            };
            Assert.AreEqual(null, controller.SaveChat(profileId, chat));
        }

        [TestMethod]
        public void DeleteChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count-1];
            Assert.AreEqual(true, controller.DeleteChat(profileId, chat.Id));
        }

        [TestMethod]
        public void DeleteNotYourChatDetails()
        {
            Chat chat = controller.GetChatsByName("", profileId)[0];
            Assert.AreEqual(false, controller.DeleteChat(0, chat.Id));
        }

        [TestMethod]
        public void DeleteChatWrongId()
        {
            Assert.AreEqual(false, controller.DeleteChat(profileId, 0));
        }

        [TestMethod]
        public void GetChatWorking()
        {
            Assert.AreNotEqual(0, controller.GetChatsByName("", profileId).Count);
        }

        [TestMethod]
        public void JoinChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            Assert.AreEqual(true, controller.JoinChat(chat.Id, profileId, new object()));
        }

        [TestMethod]
        public void JoinChatWrongChatId()
        {
            Assert.AreEqual(false, controller.JoinChat(0, profileId, new object()));
        }

        [TestMethod]
        public void JoinChatWrongProfileId()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            Assert.AreEqual(false, controller.JoinChat(chat.Id, 0, new object()));
        }

        [TestMethod]
        public void JoinExistingChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(true, controller.JoinChat(chat.Id, profileId1, new object()));
        }

        [TestMethod]
        public void JoinExistingChatTwiceFromSameProfile()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(false, controller.JoinChat(chat.Id, profileId, new object()));
        }

        [TestMethod]
        public void LeaveChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(true, controller.LeaveChat(chat.Id, profileId));
        }

        [TestMethod]
        public void LeaveChatWrongProfileId()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(false, controller.LeaveChat(chat.Id, 0));
        }

        [TestMethod]
        public void LeaveChatWrongChatId()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(false, controller.LeaveChat(0, profileId));
        }

        [TestMethod]
        public void LeaveChatIfNotJoined()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.LeaveChat(chat.Id, profileId);
            Assert.AreEqual(false, controller.LeaveChat(chat.Id, profileId));
        }

        [TestMethod]
        public void GetWorkingChat()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreNotEqual(null, controller.FindChat(chat.Id));
        }

        [TestMethod]
        public void GetNotWorkingChat()
        {
            Assert.AreEqual(null, controller.FindChat(0));
        }
    }
}
