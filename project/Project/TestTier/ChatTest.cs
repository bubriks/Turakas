using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier;
using DataTier;
using System.Collections.Generic;

namespace TestTier
{
    [TestClass]
    public class ChatTest
    {
        private ChatController controller = new ChatController();

        [TestMethod]
        public void TestCreateChatMethod()
        {
            Assert.AreNotEqual(null, controller.CreateChat(new Chat(0, "testChat", true), 1));
        }

        [TestMethod]
        public void TestGetChatsByNameMethod()
        {
            List<Chat> list = controller.GetChatsByName("");
            Assert.AreNotEqual(0, list.Count);
        }

        [TestMethod]
        public void TestUpdateChatMethod()
        {
            List<Chat> list = controller.GetChatsByName("");
            Chat chat = list[0];
            Assert.AreEqual(true, controller.UpdateChat(new Chat(chat.Id, "testingChat", true)));
        }

        [TestMethod]
        public void TestAddPersonToChatMethod()//should work if there were more than one person
        {
            int id = 0;
            foreach (Chat chat in controller.GetChatsByName(""))
            {
                List<Profile> profiles = controller.GetPersonsInChat(chat.Id);
                if (profiles.Count != 0)
                {
                    id = profiles[0].ProfileID;
                    break;
                }
            }

            foreach (Chat chat in controller.GetChatsByName(""))
            {
                List<Profile> profiles = controller.GetPersonsInChat(chat.Id);
                bool b = false;
                foreach(Profile profile in profiles)
                {
                    if(profile.ProfileID == id)
                    {
                        b = true;
                        break;
                    }
                }

                if(b)
                {
                    Assert.AreEqual(true, controller.AddPersonToChat(chat.Id, id));
                    break;
                }
                else
                {
                    Assert.AreEqual(true, false);
                }
            }
        }

        [TestMethod]
        public void TestGetPersonsChatsMethod()
        {
            foreach (Chat chat in controller.GetChatsByName(""))
            {
                List<Profile> profiles = controller.GetPersonsInChat(chat.Id);
                if (profiles.Count != 0)
                {
                    Assert.IsFalse(false);
                    break;
                }
                else
                {
                    Assert.IsFalse(true);
                }
            }
        }

        [TestMethod]
        public void TestGetPersonsInChatMethod()
        {
            foreach (Chat chat in controller.GetChatsByName(""))
            {
                if (controller.GetPersonsInChat(chat.Id).Count != 0)
                {
                    Assert.AreEqual(true, true);
                    break;
                }
                else
                {
                    Assert.AreEqual(true, false);
                }
            }
        }

        [TestMethod]
        public void TestRemovePersonFromChatMethod()
        {
            int id = 0;
            foreach (Chat chat in controller.GetChatsByName(""))
            {
                List<Profile> profiles = controller.GetPersonsInChat(chat.Id);
                if (profiles.Count != 0)
                {
                    id = profiles[0].ProfileID;
                    break;
                }
            }

            List<Chat> chats = controller.GetPersonsChats(id);
            if (chats.Count != 0)
            {
                Assert.AreEqual(true, controller.RemovePersonFromChat(chats[0].Id, id));
            }
            else
            {
                Assert.AreEqual(true, false);
            }
        }

        [TestMethod]
        public void TestDeleteChatMethod()
        {
            List<Chat> list = controller.GetChatsByName("");
            Chat chat = list[list.Count - 1];
            Assert.AreEqual(true, controller.DeleteChat(chat.Id));
        }
        
    }
}
