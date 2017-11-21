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
        public void AddSong(int activityID, int artistID, int genreID, string name, int duration, string url)
        {
            string stmt = "INSERT INTO Song(activityID, artistID, genreID, name, duration, url) values (@0, @1, @2, @3, @4, @5)";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0", activityID);
            cmd.Parameters.AddWithValue("@1", artistID);
            cmd.Parameters.AddWithValue("@2", genreID);
            cmd.Parameters.AddWithValue("@3", name);
            cmd.Parameters.AddWithValue("@4", duration);
            cmd.Parameters.AddWithValue("@5", url);
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
                    ActivityId = reader.GetInt32(reader.GetOrdinal("activityID")), 
                    ArtistId = reader.GetInt32(reader.GetOrdinal("artistID")), 
                    GenreId = reader.GetInt32(reader.GetOrdinal("genreID")), 
                    Name = reader.GetString(reader.GetOrdinal("name")), 
                    Duration = reader.GetInt32(reader.GetOrdinal("duration")), 
                    Url = reader.GetString(reader.GetOrdinal("url"))
                };
            }
            return song;
        }
    }
}