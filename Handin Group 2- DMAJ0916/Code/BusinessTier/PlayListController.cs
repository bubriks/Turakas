using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using BusinessTier.Interfaces;
using DataAccessTier;
using DataTier;
using System.Data;

namespace BusinessTier
{
    public class PlayListController: IPlayListController
    {
        private DbPlayList dbPlayList;
        private DbConnection con;
        private DbActivity dbActivity;

        public PlayListController()
        {
            dbPlayList = new DbPlayList();
            con = DbConnection.GetInstance();
            dbActivity = new DbActivity();


        }
        
        public bool AddPlayList(string name, int profileId)
        {
            using (IDbTransaction tran = DbConnection.GetInstance().BeginTransaction())
            {

                try
                {
                    int activityId = dbActivity.CreateActivity(profileId);

                    if (activityId > 0 && dbPlayList.AddPlayList(name, activityId) > 0)
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

        public List<PlayList> FindPlayListsByName(string name)
        {
            return dbPlayList.FindPlayListsByName(name);
        }

        public bool AddSongToPlayList(string url, string playListIdString, int profileId)
        {
            int playListId = 0;
            try
            {
                int songId = new SongController().GetSongByUrl(url).ActivityId;
                playListId = Int32.Parse(playListIdString);
                if (dbPlayList.IsSongInPlayList(songId, playListId))
                {
                    return false;
                }
                
                if (dbPlayList.IsPlaylistOwner(playListId, profileId)&&dbPlayList.AddSongToPlayList(songId, playListId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Song> GetSongsFromPlayList(string playListIdString)
        {
            int playListId = 0;
            try
            {
                 playListId = Int32.Parse(playListIdString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
            return dbPlayList.GetSongsFromPlayList(playListId);
        }

        public bool RemovePlaylist(string playlistIdString, int profileId)
        {
            try
            {
                int playlistId = Int32.Parse(playlistIdString);
                if (dbPlayList.IsPlaylistOwner(playlistId,profileId)&&dbPlayList.RemovePlaylist(playlistId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool RemoveSongFromPlaylist(string url, string playListIdString, int profileId)
        {
            try
            {
                int playlistId = Int32.Parse(playListIdString);
                int songId = new SongController().GetSongByUrl(url).ActivityId;
                if (dbPlayList.IsPlaylistOwner(playlistId,profileId)&&dbPlayList.RemoveSongFromPlaylist(songId, playlistId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}