﻿using System;
using System.Collections.Generic;
using DataAccessTier;
using DataTier;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BusinessTier
{
    public class SongController: ISongController
    {
        public bool AddSong(string url)
        {
            DBSong dbSong = new DBSong();
            Song song = dbSong.FindSongByURL(url);
            if (song != null)
            {
                return false;
            }
            dbSong.AddSong(GetVideoTitle(url), GetVideoDuration(url), url);
            return true;
        }

        private static YouTubeService ytService = Auth();

        private static YouTubeService Auth()
        {
            UserCredential credential;
            using (var stream = new FileStream("BusinessTier/youtube_client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore("YouTubeAPI")).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YouTubeAPI"
            });

            return service;
        }
       
        public string GetVideoTitle(string videoId)
        {
            string videoTitle = "";
            var videoRequest = ytService.Videos.List("snippet");
            videoRequest.Id = videoId;

            var response = videoRequest.Execute();
            if(response.Items.Count > 0)
            {
                videoTitle = response.Items[0].Snippet.Title;
            }
            return videoTitle;
        }

        public int GetVideoDuration(string videoId)
        {
            int videoDuration = 0;

            var videoRequest = ytService.Videos.List("contentDetails");
            videoRequest.Id = videoId;

            var response = videoRequest.Execute();
            if(response.Items.Count > 0)
            {
                string duration = response.Items[0].ContentDetails.Duration;              
                
                var durationArray = new Regex(@"PT(\d+H)?(\d+M)?(\d+S)?").Match(duration);
                string hour = durationArray.Groups[1].ToString();
                string min = durationArray.Groups[2].ToString();
                string sec = durationArray.Groups[3].ToString();

                if (!String.IsNullOrEmpty(hour))
                {
                    videoDuration += Int32.Parse(hour.Remove(hour.Length-1))*3600;
                }
                if (!String.IsNullOrEmpty(min))
                {
                    videoDuration += Int32.Parse(min.Remove(min.Length - 1)) * 60;
                }
                if (!String.IsNullOrEmpty(hour))
                {
                    videoDuration += Int32.Parse(sec.Remove(sec.Length - 1));
                }
            }
            return videoDuration;
        }

        public List<Song> FindSongsByName(string name)
        {
            DBSong dbSong = new DBSong();
            return dbSong.FindSongsByName(name);
        }

    }
}