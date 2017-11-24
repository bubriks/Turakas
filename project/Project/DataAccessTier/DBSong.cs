using System.Data.SqlClient;
using DataTier;
using System;
using System.Collections.Generic;

namespace DataAccessTier
{
    public class DBSong
    {
        private SqlConnection con = null;
        public DBSong()
        {
            con = DbConnection.GetInstance().GetConnection();
        }
        public void AddSong(string name, int duration, string url)
        {
            string stmt = " DECLARE @activityID int; " +

            " INSERT INTO Activity(profileID, timeStamp) VALUES(1, @0); " +
            " SET @activityID = @@IDENTITY; " + "INSERT INTO Song(activityID, name, duration, url) values (@activityID, @1, @2, @3)";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@1", name);
            cmd.Parameters.AddWithValue("@2", duration);
            cmd.Parameters.AddWithValue("@3", url);
            cmd.ExecuteNonQuery();
        }

        public Song FindSongByURL(string url)
        {
            Song song = null;
            string stmt = "SELECT * FROM Song WHERE url = @0";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0", url);
            SqlDataReader reader = cmd.ExecuteReader();
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
            reader.Close();
            return song;
        }

        public List<Song> FindSongsByName(string name)
        {
            List<Song> results = new List<Song>();
            name = name.Trim();
            string stmt = "SELECT * FROM Song where name";
            char[] delimiters = {' '};
            string[] keywords = name.Split(delimiters);
            
            for (int i = 0; i < keywords.Length; i++)
            {
                stmt += $"LIKE '%{keywords[i].Trim()}%'";
                if (!String.IsNullOrEmpty(keywords[i + 1].Trim()))
                {
                    stmt += " AND ";
                }
            }
            
            SqlCommand cmd = new SqlCommand(stmt, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add( new Song
                {
                    ActivityId = reader.GetInt32(reader.GetOrdinal("activityID")),
                    Name = reader.GetString(reader.GetOrdinal("name")), 
                    Duration = reader.GetInt32(reader.GetOrdinal("duration")), 
                    Url = reader.GetString(reader.GetOrdinal("url"))
                });
            }

            reader.Close();
            return results;
        }
    }
}