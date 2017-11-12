namespace BusinessTier
{
    public interface ISongController
    {
        void AddSong(int activityID, int artistID, int genreID, string name, int duration, string url);
        string GetVideoInfo(string videoId);
    }
}