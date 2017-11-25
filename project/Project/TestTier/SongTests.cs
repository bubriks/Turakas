using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier;

namespace TestTier
{
    [TestClass]
    public class SongTests
    {
        private SongController songController;

        public SongTests()
        {
            songController = new SongController();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
