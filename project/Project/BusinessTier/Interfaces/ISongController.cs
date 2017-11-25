using System.Collections.Generic;
using DataTier;

namespace BusinessTier
{
    public interface ISongController
    {
        bool AddSong(string url);
        string GetVideoTitle(string videoId);
        int GetVideoDuration(string videoId);
        List<Song> FindSongsByName(string name);


    }
}