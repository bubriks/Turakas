namespace BusinessTier
{
    public interface ISongController
    {
        bool AddSong(string name, int duration, string url);
        string GetVideoTitle(string videoId);
        int GetVideoDuration(string videoId);

    }
}