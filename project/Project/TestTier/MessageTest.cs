using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusinessTier;
using DataTier;

namespace TestTier
{
    [TestClass]
    class MessageTest
    {
        private MessageController controller = new MessageController();
        private ChatController chatController = new ChatController();
        [TestMethod]
        public void TestCreateMessageMethod()
        {
            int profileId = 0;
            int chatId = 0;
            foreach (Chat chat in chatController.GetChatsByName(""))
            {
                List<Profile> profiles = chatController.GetPersonsInChat(chat.Id);
                if (profiles.Count != 0)
                {
                    profileId = profiles[0].ProfileID;
                    chatId = chat.Id;
                    break;
                }
            }

            Assert.AreEqual(true, controller.CreateMessage(profileId, "test", chatId));
        }

        [TestMethod]
        public void TestGetMessagesMethod()
        {
            foreach (Chat chat in chatController.GetChatsByName(""))
            {
                List<Message> messages = controller.GetMessages(chat.Id);
                if (messages.Count != 0)
                {
                    Assert.AreEqual(true, true);
                    break;
                }
                else
                {
                    Assert.AreEqual(false, true);
                }
            }
        }

        [TestMethod]
        public void TestDeleteMessageMethod()
        {
            foreach (Chat chat in chatController.GetChatsByName(""))
            {
                List<Message> messages = controller.GetMessages(chat.Id);
                if (messages.Count != 0)
                {
                    Assert.AreEqual(true, controller.DeleteMessage(messages[0].Id));
                    break;
                }
                else
                {
                    Assert.AreEqual(false, true);
                }
            }
        }
    }
}
