﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract]
    public interface IYoutubeService
    {
        [OperationContract]
        bool AddSong(string url);
        [OperationContract]
        string GetVideoTitle(string videoId);
        
        [OperationContract]
        int GetVideoDuration(string videoId);
        
        [OperationContract]
        List<Song> FindSongsByName(string name);
        
        [OperationContract]
        bool AddPlayList(string name);
        [OperationContract]
        List<PlayList> FindPlayListsByName(string name);
        
        [OperationContract]
        bool AddSongToPlayList(string url, string playListId);
        
        [OperationContract]
        List<Song> GetSongsFromPlayList(string playListId);
        
        [OperationContract]
        bool RemovePlaylist(string playlistId);

        [OperationContract]
        bool RemoveSongFromPlaylist(string url, string playlistId);

    }
}
