using System.Data.SqlClient;
using DataTier;

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
            string stmt = "INSERT INTO Song(name, duration, url) values (@0, @1, @2)";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0", name);
            cmd.Parameters.AddWithValue("@1", duration);
            cmd.Parameters.AddWithValue("@2", url);
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
                    SongId = reader.GetInt32(reader.GetOrdinal("songID")),
                    Name = reader.GetString(reader.GetOrdinal("name")), 
                    Duration = reader.GetInt32(reader.GetOrdinal("duration")), 
                    Url = reader.GetString(reader.GetOrdinal("url"))
                };
            }
            return song;
        }
    }
}