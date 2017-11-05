﻿using System;
using DataAccessTier;
using DataTier;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System.IO;
using System.Threading;

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

        private static YouTubeService ytService = Auth();

        private static YouTubeService Auth()
        {
            UserCredential credential;
            using (var stream = new FileStream("youtube_client_secret.json", FileMode.Open, FileAccess.Read))
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
       
        public void GetVideoInfo(string videoId)
        {
            
            var videoRequest = ytService.Videos.List("snippet");
            
        }
    }
}