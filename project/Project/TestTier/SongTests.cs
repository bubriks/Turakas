using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier;
using System.Collections.Generic;
using DataAccessTier;
using DataTier;


namespace TestTier
{
    [TestClass]
    public class SongTests
    {
        private SongController songController;
        private DbConnection dbConnection; 

        public SongTests()
        {
            songController = new SongController();
            dbConnection = DbConnection.GetInstance();
        }
        [TestMethod]
        public void GetVideoTitleCorrect()
        {
            string s = "-3uvf0cn0jo";
            Assert.AreEqual("Candlemass - Bewitched", songController.GetVideoTitle(s));
        }
        
        [TestMethod]
        public void GetVideoTitleWrong()
        {
            string s = "874ea487r45xdfg8h4sr78947jtf45j4f87";
            Assert.AreEqual("", songController.GetVideoTitle(s));
        }

        [TestMethod]
        public void GetVideoDurationCorrectMS()
        {
            int duration = 7 * 60 + 35;
            string s = "-3uvf0cn0jo";
            Assert.AreEqual(duration, songController.GetVideoDuration(s));
        }
        
        [TestMethod]
        public void GetVideoDurationWrong()
        {
            int duration = 0;
            string s = "874ea487r45xdfg8h4sr78947jtf45j4f87";
            Assert.AreEqual(duration, songController.GetVideoDuration(s));
        }
        
        [TestMethod]
        public void GetVideoDurationS()
        {
            int duration = 20;
            string s = "0SF-oQmqaj0";
            Assert.AreEqual(duration, songController.GetVideoDuration(s));
        }
        
        [TestMethod]
        public void GetVideoDurationM()
        {
            int duration = 60;
            string s = "EXnHnPbdvzo";
            Assert.AreEqual(duration, songController.GetVideoDuration(s));
        }
        
        [TestMethod]
        public void GetVideoDurationH()
        {
            int duration = 3600 * 10;
            string s = "3QNfdiNTjk4";
            Assert.AreEqual(duration, songController.GetVideoDuration(s));
        }
        
        [TestMethod]
        public void GetVideoDurationHS()
        {
            int duration = 3605;
            string s = "qOZ1u9VpoMk";
            Assert.AreEqual(duration, songController.GetVideoDuration(s));
        }
        
        [TestMethod]
        public void GetVideoDurationHM()
        {
            int duration = 3600 + 2 * 60;
            string s = "oNeyPeXQ2J8";
            Assert.AreEqual(duration, songController.GetVideoDuration(s));
        }
        
        [TestMethod]
        public void GetVideoDurationHMS()
        {
            int duration = 3600 + 2 * 60 + 41;
            string s = "Zxd4t0QLm0";
            Assert.AreEqual(duration, songController.GetVideoDuration(s));
        }
        
        [TestMethod]
        public void FindSongByNameExisting()
        {
            string name = "Idiot Test";
            dbConnection.BeginTransaction();
            songController.AddSong("YWo4qBnSwjM");
            songController.AddSong("2a4Uxdy9TQY");
            List<string> urlsActual = new List<string>();
            List<string> urlsExpected = new List<string>();
            urlsExpected.Add("YWo4qBnSwjM");
            urlsExpected.Add("2a4Uxdy9TQY");

            List<Song> songs = songController.FindSongsByName(name);

            foreach (Song song in songs)
            {
                urlsActual.Add(song.Url);
            }
            CollectionAssert.AreEqual(urlsExpected, urlsActual);
            dbConnection.Rollback();
        }
        
        [TestMethod]
        public void FindSongByNameNonExisting()
        {
            string name = "a9ouehgtiuashdf98utghya98ey4-980yth90ugahrnsfd9-8agh-9f80dhgz";
            Assert.Equals(0, songController.FindSongsByName(name).Count);
        }
        
        [TestMethod]
        public void AddSongExisting()
        {
            dbConnection.BeginTransaction();
            songController.AddSong("YWo4qBnSwjM");
            Assert.IsFalse(songController.AddSong("YWo4qBnSwjM"));
            dbConnection.Rollback();

        }
        
        [TestMethod]
        public void AddNonExisting()
        {
            dbConnection.BeginTransaction();
            Assert.IsTrue(songController.AddSong("YWo4qBnSwjM"));
            dbConnection.Rollback();
        }
        
        

    }
}
