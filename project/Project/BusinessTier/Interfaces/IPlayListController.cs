using DataTier;
using System.Collections.Generic;

namespace BusinessTier.Interfaces
{
    public interface IPlayListController
    {
        void AddPlayList(string name);
        List<PlayList> FindPlayListsByName(string name);
        bool AddSongToPlayList(int songId, int playListId);

        List<Song> GetSongsFromPlayList(int playListId);



    }
}