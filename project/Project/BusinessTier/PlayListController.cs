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
        private DbActivity dbActivity;

        public PlayListController()
        {
            dbPlayList = new DbPlayList();
            dbActivity = new DbActivity();


        }
        
        public bool AddPlayList(string name, int profileId)
        {
            SqlConnection con = new DbConnection().GetConnection();
            try
            {
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        int activityId = dbActivity.CreateActivity(profileId, (SqlTransaction)tran, con);

                        if (activityId > 0 && dbPlayList.AddPlayList(name, activityId, (SqlTransaction)tran, con) > 0)
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

        public List<PlayList> FindPlayListsByName(string name)
        {
            SqlConnection con = new DbConnection().GetConnection();
            try
            {
                return dbPlayList.FindPlayListsByName(name, null, con);
            }
            finally
            {
                con.Close();
            }
        }

        public bool AddSongToPlayList(string url, string playListIdString, int profileId)
        {
            int playListId = 0;
            try
            {
                int songId = new SongController().GetSongByUrl(url).ActivityId;
                playListId = Int32.Parse(playListIdString);
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    if (dbPlayList.IsSongInPlayList(songId, playListId, null, con))
                    {
                        return false;
                    }

                    if (dbPlayList.IsPlaylistOwner(playListId, profileId, null, con) && dbPlayList.AddSongToPlayList(songId, playListId, null, con) > 0)
                    {
                        return true;
                    }
                }
                finally
                {
                    con.Close();
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
            SqlConnection con = new DbConnection().GetConnection();
            try
            {
                return dbPlayList.GetSongsFromPlayList(playListId, null, con);
            }
            finally
            {
                con.Close();
            }
        }

        public bool RemovePlaylist(string playlistIdString, int profileId)
        {
            try
            {
                int playlistId = Int32.Parse(playlistIdString);
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    if (dbPlayList.IsPlaylistOwner(playlistId, profileId, null, con) && dbPlayList.RemovePlaylist(playlistId, null, con) > 0)
                    {
                        return true;
                    }
                }
                finally
                {
                    con.Close();
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
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    if (dbPlayList.IsPlaylistOwner(playlistId, profileId, null, con) && dbPlayList.RemoveSongFromPlaylist(songId, playlistId, null, con) > 0)
                    {
                        return true;
                    }
                }
                finally
                {
                    con.Close();
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