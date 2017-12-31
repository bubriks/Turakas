using System.Data.SqlClient;
using DataTier;
using System;
using System.Collections.Generic;

namespace DataAccessTier
{
    public class DBSong
    {
        private DbConnection con = null;
        public DBSong()
        {
            con = DbConnection.GetInstance();
        }
        public int AddSong(string name, int duration, string url, int activityId, SqlTransaction transaction)
        {
            string stmt = "INSERT INTO Video(activityID, name, duration, url) values (@0, @1, @2, @3)";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), transaction))
            {
                cmd.Parameters.AddWithValue("@0", activityId);
                cmd.Parameters.AddWithValue("@1", name);
                cmd.Parameters.AddWithValue("@2", duration);
                cmd.Parameters.AddWithValue("@3", url);
                return cmd.ExecuteNonQuery();
            }
            
        }

        public Song FindSongByURL(string url, SqlTransaction transaction)
        {
            Song song = null;
            string stmt = "SELECT * FROM Video WHERE url = @0";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), transaction))
            {
                cmd.Parameters.AddWithValue("@0", url);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        song = new Song
                        {
                            ActivityId = reader.GetInt32(reader.GetOrdinal("activityID")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Duration = reader.GetInt32(reader.GetOrdinal("duration")),
                            Url = reader.GetString(reader.GetOrdinal("url"))
                        };
                    }
                    return song;
                }
            }
        }

        public List<Song> FindSongsByName(string name, SqlTransaction transaction)
        {
            List<Song> results = new List<Song>();
            name = name.Trim();
            string stmt = "SELECT * FROM Video where name ";
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
                catch (IndexOutOfRangeException)
                {
                    
                }
            }

            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), transaction))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new Song
                        {
                            ActivityId = reader.GetInt32(reader.GetOrdinal("activityID")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Duration = reader.GetInt32(reader.GetOrdinal("duration")),
                            Url = reader.GetString(reader.GetOrdinal("url"))
                        });
                    }
                    
                    return results;
                }
            }
            
        }
    }
}