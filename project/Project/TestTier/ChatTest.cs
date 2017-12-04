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

        #region Create chat
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
            Assert.AreEqual(true, controller.SaveChat(profileId, chat));
        }

        [TestMethod]
        public void CreateChatWithWronProfileDetails()
        {
            Chat chat = new Chat
            {
                MaxNrOfUsers = 2,
                Name = "testChat",
                OwnerID = 0,
                Type = true
            };
            Assert.AreEqual(false, controller.SaveChat(profileId, chat));
        }

        [TestMethod]
        public void CreateChatWithEmptyNameDetails()
        {
            Chat chat = new Chat
            {
                MaxNrOfUsers = 2,
                Name = "",
                OwnerID = profileId,
                Type = true
            };
            Assert.AreEqual(false, controller.SaveChat(profileId, chat));
        }

        [TestMethod]
        public void CreateChatWithWrongPersonLimitDetails()
        {
            Chat chat = new Chat
            {
                MaxNrOfUsers = 1,
                Name = "testChat",
                OwnerID = profileId,
                Type = true
            };
            Assert.AreEqual(false, controller.SaveChat(profileId, chat));
        }
        #endregion

        #region Update chat
        [TestMethod]
        public void UpdateChatWorking()
        {
            Chat chat = controller.GetChatsByName("", profileId)[0];
            chat.Type = true;
            Assert.AreEqual(true, controller.SaveChat(chat.OwnerID, chat));
        }

        [TestMethod]
        public void UpdateNotYourChatDetails()
        {
            Chat chat = controller.GetChatsByName("", profileId)[0];
            chat.Type = true;
            Assert.AreEqual(false, controller.SaveChat(0, chat));
        }

        [TestMethod]
        public void UpdatChatNoName()
        {
            Chat chat = controller.GetChatsByName("", profileId)[0];
            chat.Name = "";
            Assert.AreEqual(false, controller.SaveChat(chat.Id, chat));
        }

        [TestMethod]
        public void UpdatChatNotEnoughProfileLimit()
        {
            Chat chat = controller.GetChatsByName("", profileId)[0];
            chat.MaxNrOfUsers = 1;
            Assert.AreEqual(false, controller.SaveChat(chat.OwnerID, chat));
        }
        #endregion

        #region Delete chat
        [TestMethod]
        public void DeleteChatWorking()
        {
            Chat chat = new Chat
            {
                MaxNrOfUsers = 2,
                Name = "testChat",
                OwnerID = profileId,
                Type = true
            };
            controller.SaveChat(profileId, chat);
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Assert.AreEqual(true, controller.DeleteChat(chat.OwnerID, chats[chats.Count -1].Id));
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
        #endregion

        #region Get chats
        [TestMethod]
        public void GetChatsWorking()
        {
            Assert.AreNotEqual(0, controller.GetChatsByName("", profileId).Count);
        }
        #endregion

        #region Join chat with group
        [TestMethod]
        public void JoinChatWithWrongChatId()
        {
            Assert.AreEqual(0, controller.JoinChatWithGroup((new GroupController().GetUsersGroups(profileId))[0].GroupId, 0).Count);
        }

        [TestMethod]
        public void JoinChatWithWrongGroupId()
        {
            Assert.AreEqual(0, controller.JoinChatWithGroup(0, (controller.GetChatsByName("", profileId))[0].Id).Count);
        }
        #endregion

        #region Join chat
        [TestMethod]
        public void JoinChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            Assert.AreEqual(true, controller.JoinChat(chat.Id, profileId, null));
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
            controller.LeaveChat(chat.Id, profileId);
            Assert.AreEqual(false, controller.JoinChat(chat.Id, 0, new object()));
        }

        [TestMethod]
        public void JoinExistingChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            new ProfileController().Online(profileId1, new object());
            controller.JoinChat(chat.Id, profileId1, new object());
            Assert.AreEqual(true, controller.JoinChat(chat.Id, profileId, new object()));
        }

        [TestMethod]
        public void JoinExistingChatTwiceFromSameProfile()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(false, controller.JoinChat(chat.Id, profileId, new object()));
        }

        [TestMethod]
        public void JoinExistingChatWhenDontHaveCallBack()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.LeaveChat(chat.Id, profileId);
            controller.JoinChat(chat.Id, profileId, null);
            Assert.AreEqual(true, controller.JoinChat(chat.Id, profileId, new object()));
        }

        [TestMethod]
        public void JoinExistingChatWhenHaveCallBack()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(false, controller.JoinChat(chat.Id, profileId, new object()));
        }
        #endregion

        #region Leave chat
        [TestMethod]
        public void LeaveChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(true, controller.LeaveChat(chat.Id, profileId));
        }

        [TestMethod]
        public void LeaveChatWrongProfileId()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreEqual(false, controller.LeaveChat(chat.Id, 0));
        }

        [TestMethod]
        public void LeaveChatWrongChatId()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
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
        #endregion

        #region Find chat
        [TestMethod]
        public void FindWorkingChat()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.JoinChat(chat.Id, profileId, new object());
            Assert.AreNotEqual(null, controller.FindChat(chat.Id));
        }

        [TestMethod]
        public void FindNotWorkingChat()
        {
            Assert.AreEqual(null, controller.FindChat(0));
        }
        #endregion
    }
}
