﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract]
    public interface IYoutubeService
    {
        [OperationContract]
        void AddSong(int activityID, int artistID, int genreID, string name, int duration, string url);
        [OperationContract]
        string GetVideoInfo(string videoId);
    }
}
