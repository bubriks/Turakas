using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbArtist
    {
        private SqlConnection con = null;

        public DbArtist()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        public void AddArtist(int artistID, string name)
        {
            string stmt = "INSERT INTO Artist(artistID, name) values (@0, @1)";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0", artistID);
            cmd.Parameters.AddWithValue("@1", name);
            cmd.ExecuteNonQuery();
        }
    }
}