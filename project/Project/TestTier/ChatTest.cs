using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier;
using DataTier;

namespace TestTier
{
    [TestClass]
    public class ChatTest
    {
        private ChatController controller = new ChatController();
        private Chat chat = null;

        //tests will be automized later in the futuer and will have also test for failures

        [TestMethod]
        public void TestCreateChatMethod()
        {
            chat = controller.CreateChat(new Chat(0, "testChat", true),1);
            Assert.AreNotEqual(null, chat);
        }

        [TestMethod]
        public void TestGetChatMethod()
        {
            Assert.AreNotEqual(null, controller.GetChat(1));
        }

        [TestMethod]
        public void TestUpdateChatMethod()
        {
            Assert.AreEqual(true, controller.UpdateChat(new Chat(1, "testingChat", true)));
        }

        [TestMethod]
        public void TestAddPersonToChatMethod()
        {
            Assert.AreEqual(true, controller.AddPersonToChat(1,1));
        }

        [TestMethod]
        public void TestGetPersonInChatMethod()
        {
            Assert.AreNotEqual(null, controller.GetPersonsInChat(1));
        }

        [TestMethod]
        public void TestRemovePersonFromChatMethod()
        {
            Assert.AreEqual(true, controller.RemovePersonFromChat(1,1));
        }

        [TestMethod]
        public void TestDeleteChatMethod()
        {
            Assert.AreEqual(true, controller.DeleteChat(2));
        }
    }
}
