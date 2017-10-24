using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier;

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
    }
}
