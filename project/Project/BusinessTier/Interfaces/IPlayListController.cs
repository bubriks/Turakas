using DataTier;
using System.Collections.Generic;

namespace BusinessTier.Interfaces
{
    public interface IPlayListController
    {
        bool AddPlayList(string name);
        List<PlayList> FindPlayListsByName(string name);
        bool AddSongToPlayList(string url, string playListId);
        List<Song> GetSongsFromPlayList(string playListId);
        bool RemovePlaylist(string playlistId);
        bool RemoveSongFromPlaylist(string url, string playListId);
    }
}