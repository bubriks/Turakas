using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbGenre
    {
        private SqlConnection con = null;

        public DbGenre()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        public void AddArtist(int genreID, string name)
        {
            string stmt = "INSERT INTO Genre(genreID, name) values (@0, @1)";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0", genreID);
            cmd.Parameters.AddWithValue("@1", name);
            cmd.ExecuteNonQuery();
        }
    }
}