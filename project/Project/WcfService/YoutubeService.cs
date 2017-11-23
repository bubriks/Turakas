using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;

namespace WcfService
{
    public class YoutubeService : IYoutubeService
    {
        ISongController songController = new SongController();

        public void AddSong(int activityID, string name, int duration, string url)
        {
            songController.AddSong(activityID, name, duration, url);
        }
        public string GetVideoTitle(string videoId)
        {
            return songController.GetVideoTitle(videoId);

        }

        public int GetVideoDuration(string videoId)
        {
            return songController.GetVideoDuration(videoId);
        }
    }
}
