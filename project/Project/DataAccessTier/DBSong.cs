using System.Data.SqlClient;

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
    }
}