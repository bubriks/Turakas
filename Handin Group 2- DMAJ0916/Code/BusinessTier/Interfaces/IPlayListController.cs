using DataTier;
using System.Collections.Generic;

namespace BusinessTier.Interfaces
{
    public interface IPlayListController
    {
        bool AddPlayList(string name, int profileId);
        List<PlayList> FindPlayListsByName(string name);
        bool AddSongToPlayList(string url, string playListId, int profileId);
        List<Song> GetSongsFromPlayList(string playListId);
        bool RemovePlaylist(string playlistId, int profileId);
        bool RemoveSongFromPlaylist(string url, string playListId, int profileId);
    }
}