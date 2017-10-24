using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier;
using DataTier;

namespace TestTier
{
    [TestClass]
    public class ChatTest
    {
        ChatController controller = new ChatController();

        [TestMethod]
        public void TestGetChatMethod()
        {
            Assert.AreNotEqual(null, controller.GetChat(1));
        }

        [TestMethod]
        public void TestUpdateChatMethod()
        {
            Assert.AreEqual(true, controller.UpdateChat(new Chat(1,"randomTest",false)));
        }
    }
}
