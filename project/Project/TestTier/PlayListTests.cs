using System;
using BusinessTier;
using DataAccessTier;
using DataTier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTier
{
    [TestClass]
    public class PlayListTests
    {
        private PlayListController playListController;
        private SongController songController;
        private DbActivity dbActivity;

        public PlayListTests()
        {
            playListController = new PlayListController();
            songController = new SongController();
            dbActivity = new DbActivity();
            
        }
        [TestMethod]
        public void AddPlayListExistingProfile()
        {
            Assert.IsTrue(playListController.AddPlayList("geschwindigkeitsbegrenzung", 1));
            playListController.RemovePlaylist(
                playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0].ActivityId.ToString(), 1);
        }
        
        [TestMethod]
        public void AddPlayListNonExistingProfile()
        {
            Assert.IsFalse(playListController.AddPlayList("geschwindigkeitsbegrenzung", 0));
        }
        
        [TestMethod]
        public void FindPlayListExisting()
        {
            playListController.AddPlayList("geschwindigkeitsbegrenzung", 1);
            PlayList playList = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0];
            Assert.AreEqual("geschwindigkeitsbegrenzung", playList.Name);
            playListController.RemovePlaylist(playList.ActivityId.ToString(), 1);
        }
        
        [TestMethod]
        public void FindPlayListNonExisting()
        {
            int count = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung").Count;
            Assert.AreEqual(0,count);
        }
        
        [TestMethod]
        public void AddSongToPlaylist()
        {
            playListController.AddPlayList("geschwindigkeitsbegrenzung", 1);
            PlayList playList = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0];
            songController.AddSong("YWo4qBnSwjM", 1);
            Song song = songController.GetSongByUrl("YWo4qBnSwjM");
            playListController.AddSongToPlayList("YWo4qBnSwjM", playList.ActivityId.ToString(), 1);
            
            Assert.AreEqual(song.Url, playListController.GetSongsFromPlayList(playList.ActivityId.ToString())[0].Url);
            dbActivity.DeleteActivity(1, playList.ActivityId, null);
            dbActivity.DeleteActivity(1, song.ActivityId, null);

        }
        [TestMethod]
        public void AddSongTopPlaylistSongAlreadyExists()
        {
            playListController.AddPlayList("geschwindigkeitsbegrenzung", 1);
            PlayList playList = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0];
            songController.AddSong("YWo4qBnSwjM", 1);
            Song song = songController.GetSongByUrl("YWo4qBnSwjM");
            playListController.AddSongToPlayList("YWo4qBnSwjM", playList.ActivityId.ToString(), 1);
            playListController.AddSongToPlayList("YWo4qBnSwjM", playList.ActivityId.ToString(), 1);
            Assert.AreEqual(1,playListController.GetSongsFromPlayList(playList.ActivityId.ToString()).Count);
            dbActivity.DeleteActivity(1,playList.ActivityId, null);
            dbActivity.DeleteActivity(1, song.ActivityId, null);
        }
        [TestMethod]
        public void AddSongToPlaylistNotOwner()
        {
            playListController.AddPlayList("geschwindigkeitsbegrenzung", 1);
            PlayList playList = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0];
            songController.AddSong("YWo4qBnSwjM", 1);
            Song song = songController.GetSongByUrl("YWo4qBnSwjM");
            playListController.AddSongToPlayList("YWo4qBnSwjM", playList.ActivityId.ToString(), 2);
            Assert.AreEqual(0,playListController.GetSongsFromPlayList(playList.ActivityId.ToString()).Count);
            dbActivity.DeleteActivity(1,playList.ActivityId, null);
            dbActivity.DeleteActivity(1,song.ActivityId, null);
        }
        [TestMethod]
        public void GetSongsFromExistingPlaylist()
        {
            playListController.AddPlayList("geschwindigkeitsbegrenzung", 1);
            songController.AddSong("YWo4qBnSwjM", 1);
            PlayList playList = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0];
            playListController.AddSongToPlayList("YWo4qBnSwjM", playList.ActivityId.ToString(), 1);
            Song song = playListController.GetSongsFromPlayList(playList.ActivityId.ToString())[0];
            Assert.AreEqual("YWo4qBnSwjM", song.Url);
            playListController.RemovePlaylist(playList.ActivityId.ToString(), 1);
            dbActivity.DeleteActivity(1, song.ActivityId, null);
        }
        [TestMethod]
        public void GetSongsFromEmptyPlaylist()
        {
            playListController.AddPlayList("geschwindigkeitsbegrenzung", 1);
            PlayList playList = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0];
            int count = playListController.GetSongsFromPlayList(playList.ActivityId.ToString()).Count;
            Assert.AreEqual(0, count);
            playListController.RemovePlaylist(playList.ActivityId.ToString(), 1);
        }
        [TestMethod]
        public void GetSongsFromNonExistingPlaylists()
        {
            int id = -1;
            int count = playListController.GetSongsFromPlayList(id.ToString()).Count;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void RemovePlaylist()
        {
            playListController.AddPlayList("geschwindigkeitsbegrenzung", 1);
            PlayList playList = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0];
            playListController.RemovePlaylist(playList.ActivityId.ToString(), 1);
            int count = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung").Count;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void RemovePlaylistNotOwner()
        {
            playListController.AddPlayList("geschwindigkeitsbegrenzung", 1);
            PlayList playList = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung")[0];
            playListController.RemovePlaylist(playList.ActivityId.ToString(), 2);
            int count = playListController.FindPlayListsByName("geschwindigkeitsbegrenzung").Count;
            Assert.AreEqual(1, count);
            playListController.RemovePlaylist(playList.ActivityId.ToString(), 1);
        }
        [TestMethod]
        public void RemoveNonExistentPlaylist()
        {
            int id = -1;
            Assert.IsFalse(playListController.RemovePlaylist(id.ToString(),1));
        }
        
        
    }
}
