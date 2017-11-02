using DataAccessTier;
using DataTier;

namespace BusinessTier
{
    public class SongController: ISongController
    {
        public void AddSong(int activityID, int artistID, int genreID, string name, int duration, string url)
        {
            DBSong dbSong = new DBSong();
            Song song = dbSong.FindSongByURL(url);
            if (song != null)
            {
                dbSong.AddSong(song.ActivityId, song.ArtistId, song.GenreId, song.Name, song.Duration, song.Url);
            }
        }
    }
}