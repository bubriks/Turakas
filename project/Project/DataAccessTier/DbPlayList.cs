using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataTier;

namespace DataAccessTier
{
    public class DbPlayList
    {
        public int AddPlayList(string name, int activityId, SqlTransaction transaction, SqlConnection connection)
        {
            string stmt = "INSERT INTO PlayLists(activityID, name) values (@0, @1)";
            using (SqlCommand cmd = new SqlCommand(stmt, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@0", activityId);
                cmd.Parameters.AddWithValue("@1", name);
                return cmd.ExecuteNonQuery();
            }
        }
        
        public List<PlayList> FindPlayListsByName(string name, SqlTransaction transaction, SqlConnection connection)
        {
            List<PlayList> results = new List<PlayList>();
            name = name.Trim();
            string stmt = "SELECT * FROM PlayLists where name ";
            char[] delimiters = {' '};
            string[] keywords = name.Split(delimiters);
            
            for (int i = 0; i < keywords.Length; i++)
            {
                stmt += $"LIKE '%{keywords[i].Trim()}%'";
                
                try
                {
                    string next = keywords[i + 1];
                    stmt += " AND name ";
                }
                catch (System.IndexOutOfRangeException)
                {
                    
                }
            }

            using (SqlCommand cmd = new SqlCommand(stmt, connection, transaction))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new PlayList()
                        {
                            ActivityId = reader.GetInt32(reader.GetOrdinal("activityID")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                        });
                    }
                    
                    return results;
                }
            }
        }

        public int AddSongToPlayList(int songId, int playListId, SqlTransaction transaction, SqlConnection connection)
        {
            string stmt = " INSERT INTO VideoList(videoID, playListActivityId) VALUES(@0, @1); ";
            using (SqlCommand cmd = new SqlCommand(stmt, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@0", songId);
                cmd.Parameters.AddWithValue("@1", playListId);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Song> GetSongsFromPlayList(int playListId, SqlTransaction transaction, SqlConnection connection)
        {
            List<Song> songs = new List<Song>();
            string stmt = "Select VideoList.playListActivityID, Video.ActivityID, Video.name, Video.duration, " +
                          "Video.url FROM VideoList  INNER JOIN  Video on " +
                          "VideoList.VideoID = Video.ActivityID WHERE VideoList.PlayListActivityID = @0 ";
            using (SqlCommand cmd = new SqlCommand(stmt, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@0", playListId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        songs.Add(new Song
                        {
                            ActivityId = reader.GetInt32(reader.GetOrdinal("activityID")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Duration = reader.GetInt32(reader.GetOrdinal("duration")),
                            Url = reader.GetString(reader.GetOrdinal("url"))
                        });
                    }

                    return songs;
                }
            }
        }

        public bool IsSongInPlayList(int songId, int playListId, SqlTransaction transaction, SqlConnection connection)
        {
            string stmt = " SELECT * FROM VideoList WHERE videoId = @0 AND playListActivityID = @1; ";
            using (SqlCommand cmd = new SqlCommand(stmt, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@0", songId);
                cmd.Parameters.AddWithValue("@1", playListId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        //fix this (has to be removed and used stuff from activityDb)
        public int RemovePlaylist(int playlistId, SqlTransaction transaction, SqlConnection connection)
        {
            string stmt = "DELETE FROM Activity where ActivityId = @0";
            using (SqlCommand cmd = new SqlCommand(stmt, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@0", playlistId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int RemoveSongFromPlaylist(int songId, int playlistId, SqlTransaction transaction, SqlConnection connection)
        {
            string stmt = "DELETE FROM VideoList where VideoID = @0 AND playListActivityID = @1";
            using (SqlCommand cmd = new SqlCommand(stmt, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@0", songId);
                cmd.Parameters.AddWithValue("@1", playlistId);
                return cmd.ExecuteNonQuery();
            }
        }

        public bool IsPlaylistOwner(int playlistId, int profileId, SqlTransaction transaction, SqlConnection connection)
        {
            string stmt = " SELECT * FROM Activity WHERE activityID = @0 AND profileID = @1; ";
            using (SqlCommand cmd = new SqlCommand(stmt, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@0", playlistId);
                cmd.Parameters.AddWithValue("@1", profileId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

    }
}