namespace BusinessTier
{
    public interface ISongController
    {
        void AddSong(int activityID, string name, int duration, string url);
        string GetVideoTitle(string videoId);
        int GetVideoDuration(string videoId);

    }
}