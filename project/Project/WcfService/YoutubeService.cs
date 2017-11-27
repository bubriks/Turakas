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
    public class YoutubeService : IYoutubeService
    {
        ISongController songController = new SongController();
        IPlayListController playListController = new PlayListController();

        public bool AddSong(string url)
        {
           return songController.AddSong(url);
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

        public bool AddPlayList(string name)
        {
           return playListController.AddPlayList(name);
        }

        public List<PlayList> FindPlayListsByName(string name)
        {
            return playListController.FindPlayListsByName(name);
        }

        public bool AddSongToPlayList(string url, string playListId)
        {
            return playListController.AddSongToPlayList(url, playListId);
        }

        public List<Song> GetSongsFromPlayList(string playListId)
        {
            return playListController.GetSongsFromPlayList(playListId);
        }

        public bool RemovePlaylist(string playlistId)
        {
            return playListController.RemovePlaylist(playlistId);
        }

        public bool RemoveSongFromPlaylist(string url, string playListId)
        {
            return playListController.RemoveSongFromPlaylist(url, playListId);
        }

    }
}
