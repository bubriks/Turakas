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

        public void AddSong(int activityID, int artistID, int genreID, string name, int duration, string url)
        {
            songController.AddSong(activityID, artistID, genreID, name, duration, url);
        }
        public string GetVideoInfo(string videoId)
        {
            return songController.GetVideoInfo(videoId);

        }
    }
}
