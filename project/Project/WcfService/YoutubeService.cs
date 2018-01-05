using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;
using BusinessTier.Interfaces;

namespace WcfService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class YoutubeService : IYoutubeService
    {
        private ISongController songController = new SongController();
        private IPlayListController playListController = new PlayListController();

        public bool AddSong(string url, int profileId)
        {
           return songController.AddSong(url, profileId);
        }

        public string GetVideoTitle(string videoId)
        {
            return songController.GetVideoTitle(videoId);

        }

        public int GetVideoDuration(string videoId)
        {
            return songController.GetVideoDuration(videoId);
        }

        public List<Song> FindSongsByName(string name)
        {
            return songController.FindSongsByName(name);
        }

        public bool AddPlayList(string name, int profileId)
        {
           return playListController.AddPlayList(name, profileId);
        }

        public List<PlayList> FindPlayListsByName(string name)
        {
            return playListController.FindPlayListsByName(name);
        }

        public bool AddSongToPlayList(string url, string playListId, int profileId)
        {
            return playListController.AddSongToPlayList(url, playListId, profileId);
        }

        public List<Song> GetSongsFromPlayList(string playListId)
        {
            return playListController.GetSongsFromPlayList(playListId);
        }

        public bool RemovePlaylist(string playlistId, int profileId)
        {
            return playListController.RemovePlaylist(playlistId, profileId);
        }

        public bool RemoveSongFromPlaylist(string url, string playListId, int profileId)
        {
            return playListController.RemoveSongFromPlaylist(url, playListId, profileId);
        }
    }
}
