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
                ProfileId = profileId,
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
                ProfileId = 0,
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
                ProfileId = profileId,
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
                ProfileId = profileId,
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
            Assert.AreEqual(true, controller.SaveChat(chat.ProfileId, chat));
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
            Assert.AreEqual(false, controller.SaveChat(chat.ActivityId, chat));
        }

        [TestMethod]
        public void UpdatChatNotEnoughProfileLimit()
        {
            Chat chat = controller.GetChatsByName("", profileId)[0];
            chat.MaxNrOfUsers = 1;
            Assert.AreEqual(false, controller.SaveChat(chat.ProfileId, chat));
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
                ProfileId = profileId,
                Type = true
            };
            controller.SaveChat(profileId, chat);
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Assert.AreEqual(true, controller.DeleteChat(chat.ProfileId, chats[chats.Count -1].ActivityId));
        }

        [TestMethod]
        public void DeleteNotYourChatDetails()
        {
            Chat chat = controller.GetChatsByName("", profileId)[0];
            Assert.AreEqual(false, controller.DeleteChat(0, chat.ActivityId));
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
            Assert.AreEqual(0, controller.JoinChatWithGroup((new GroupController().GetUsersGroups(profileId))[0].ActivityId, 0).Count);
        }

        [TestMethod]
        public void JoinChatWithWrongGroupId()
        {
            Assert.AreEqual(0, controller.JoinChatWithGroup(0, (controller.GetChatsByName("", profileId))[0].ActivityId).Count);
        }
        #endregion

        #region Join chat
        [TestMethod]
        public void JoinChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            Assert.AreEqual(true, controller.JoinChat(chat.ActivityId, profileId, null, ""));
        }

        [TestMethod]
        public void JoinChatWrongChatId()
        {
            Assert.AreEqual(false, controller.JoinChat(0, profileId, new object(), ""));
        }

        [TestMethod]
        public void JoinChatWrongProfileId()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.LeaveChat(chat.ActivityId, profileId);
            Assert.AreEqual(false, controller.JoinChat(chat.ActivityId, 0, new object(), ""));
        }

        [TestMethod]
        public void JoinExistingChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            new ProfileController().Online(profileId1, new object());
            controller.JoinChat(chat.ActivityId, profileId1, new object(), "");
            Assert.AreEqual(true, controller.JoinChat(chat.ActivityId, profileId, new object(), ""));
        }

        [TestMethod]
        public void JoinExistingChatTwiceFromSameProfile()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.ActivityId, profileId, new object(), "");
            Assert.AreEqual(false, controller.JoinChat(chat.ActivityId, profileId, new object(), ""));
        }

        [TestMethod]
        public void JoinExistingChatWhenDontHaveCallBack()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.LeaveChat(chat.ActivityId, profileId);
            controller.JoinChat(chat.ActivityId, profileId, null, "");
            Assert.AreEqual(true, controller.JoinChat(chat.ActivityId, profileId, new object(), ""));
        }

        [TestMethod]
        public void JoinExistingChatWhenHaveCallBack()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.ActivityId, profileId, new object(), "");
            Assert.AreEqual(false, controller.JoinChat(chat.ActivityId, profileId, new object(), ""));
        }
        #endregion

        #region Leave chat
        [TestMethod]
        public void LeaveChatWorking()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.ActivityId, profileId, new object(), "");
            Assert.AreEqual(true, controller.LeaveChat(chat.ActivityId, profileId));
        }

        [TestMethod]
        public void LeaveChatWrongProfileId()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.ActivityId, profileId, new object(), "");
            Assert.AreEqual(false, controller.LeaveChat(chat.ActivityId, 0));
        }

        [TestMethod]
        public void LeaveChatWrongChatId()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            new ProfileController().Online(profileId, new object());
            controller.JoinChat(chat.ActivityId, profileId, new object(), "");
            Assert.AreEqual(false, controller.LeaveChat(0, profileId));
        }

        [TestMethod]
        public void LeaveChatIfNotJoined()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.LeaveChat(chat.ActivityId, profileId);
            Assert.AreEqual(false, controller.LeaveChat(chat.ActivityId, profileId));
        }
        #endregion

        #region Find chat
        [TestMethod]
        public void FindWorkingChat()
        {
            List<Chat> chats = controller.GetChatsByName("", profileId);
            Chat chat = chats[chats.Count - 1];
            controller.JoinChat(chat.ActivityId, profileId, new object(), "");
            Assert.AreNotEqual(null, controller.FindChat(chat.ActivityId));
        }

        [TestMethod]
        public void FindNotWorkingChat()
        {
            Assert.AreEqual(null, controller.FindChat(0));
        }
        #endregion
    }
}
