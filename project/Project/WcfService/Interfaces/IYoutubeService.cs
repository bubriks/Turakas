using System;
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
        bool AddSongToPlayList(int songId, int playListId);
        
        [OperationContract]
        List<Song> GetSongsFromPlayList(int playListId);
        
        [OperationContract]
        bool RemovePlaylist(int playlistId);
    }
}
