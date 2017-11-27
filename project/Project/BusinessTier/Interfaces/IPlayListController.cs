using DataTier;
using System.Collections.Generic;

namespace BusinessTier.Interfaces
{
    public interface IPlayListController
    {
        bool AddPlayList(string name);
        List<PlayList> FindPlayListsByName(string name);
        bool AddSongToPlayList(int songId, int playListId);
        List<Song> GetSongsFromPlayList(int playListId);
        bool RemovePlaylist(int playlistId);
    }
}