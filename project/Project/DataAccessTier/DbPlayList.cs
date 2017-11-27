using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataTier;

namespace DataAccessTier
{
    public class DbPlayList
    {
        private SqlConnection con = null;
        public DbPlayList()
        {
            con = DbConnection.GetInstance().GetConnection();
        }
        
        public int AddPlayList(string name)
        {
            string stmt = " DECLARE @activityID int; " +

                          " INSERT INTO Activity(profileID, timeStamp) VALUES(1, @0); " +
                          " SET @activityID = @@IDENTITY; " + "INSERT INTO PlayLists(activityID, name) values (@activityID, @1)";
            using (SqlCommand cmd = new SqlCommand(stmt, con))
            {
                cmd.Parameters.AddWithValue("@0", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                cmd.Parameters.AddWithValue("@1", name);
                return cmd.ExecuteNonQuery();
            }
        }
        
        public List<PlayList> FindPlayListsByName(string name)
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

            using (SqlCommand cmd = new SqlCommand(stmt, con))
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

        public int AddSongToPlayList(int songId, int playListId)
        {
            string stmt = " INSERT INTO VideoList(videoID, playListActivityId) VALUES(@0, @1); ";
            using (SqlCommand cmd = new SqlCommand(stmt, con))
            {
                cmd.Parameters.AddWithValue("@0", songId);
                cmd.Parameters.AddWithValue("@1", playListId);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Song> GetSongsFromPlayList(int playListId)
        {
            List<Song> songs = new List<Song>();
            string stmt = "Select VideoList.playListActivityID, Video.ActivityID, Video.name, Video.duration, " +
                          "Video.url FROM VideoList  INNER JOIN  Video on " +
                          "VideoList.VideoID = Video.ActivityID WHERE VideoList.PlayListActivityID = @0 ";
            using (SqlCommand cmd = new SqlCommand(stmt, con))
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

        public bool IsSongInPlayList(int songId, int playListId)
        {
            string stmt = " SELECT * FROM VideoList WHERE videoId = @0 AND playListActivityID = @1; ";
            using (SqlCommand cmd = new SqlCommand(stmt, con))
            {
                cmd.Parameters.AddWithValue("@0", songId);
                cmd.Parameters.AddWithValue("@1", playListId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        public int RemovePlaylist(int playlistId)
        {
            string stmt = "DELETE FROM Activity where ActivityId = @0";
            using (SqlCommand cmd = new SqlCommand(stmt, con))
            {
                cmd.Parameters.AddWithValue("@0", playlistId);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}