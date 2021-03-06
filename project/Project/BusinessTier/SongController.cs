﻿﻿using System;
using System.Collections.Generic;
using DataAccessTier;
using DataTier;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System.Threading;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

namespace BusinessTier
{
    public class SongController: ISongController
    {
        private static YouTubeService ytService;
        public SongController()
        {
            ytService = Auth();

        }
        public bool AddSong(string url, int profileId)
        {
            DBSong dbSong = new DBSong();
            DbActivity dbActivity = new DbActivity();
            SqlConnection con = new DbConnection().GetConnection();
            try
            {
                using (IDbTransaction tran = con.BeginTransaction())
                {

                    try
                    {
                        Song song = dbSong.FindSongByURL(url, (SqlTransaction)tran, con);
                        if (song != null)
                        {
                            return false;
                        }

                        int activityId = dbActivity.CreateActivity(profileId, (SqlTransaction)tran, con);
                        if (activityId > 0 && dbSong.AddSong(GetVideoTitle(url), GetVideoDuration(url), url, activityId, (SqlTransaction)tran, con) > 0)
                        {
                            tran.Commit();
                            return true;
                        }
                        else
                        {
                            tran.Rollback();
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        return false;
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private YouTubeService Auth()
        {
            UserCredential credential;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BusinessTier.Resources.youtube_client_secret.json"))
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
                if (!String.IsNullOrEmpty(sec))
                {
                    videoDuration += Int32.Parse(sec.Remove(sec.Length - 1));
                }
            }
            return videoDuration;
        }

        public List<Song> FindSongsByName(string name)
        {
            DBSong dbSong = new DBSong();
            SqlConnection con = new DbConnection().GetConnection();
            try
            {
                return dbSong.FindSongsByName(name, null, con);
            }
            finally
            {
                con.Close();
            }
        }

        public Song GetSongByUrl(string url)
        {
            SqlConnection con = new DbConnection().GetConnection();
            try
            {
                return new DBSong().FindSongByURL(url, null, con);
            }
            finally
            {
                con.Close();
            }
        }
    }
}