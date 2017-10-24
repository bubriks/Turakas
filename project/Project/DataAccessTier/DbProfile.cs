using DataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public class DbProfile
    {
        private SqlConnection con = null;

        public DbProfile()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        public Profile GetProfile(int id)
        {
            try
            {
                string stmt = "SELECT * FROM Profile where profileID = " + id;
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Profile profile = new Profile(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                    reader.Close();
                    return profile;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CreateProfile(Profile profile)
        {
            try
            {
                string stmt = "INSERT INTO Profile(profileID, statusId, nickname)" +
                    " values (" + profile.ProfileID + ", " + profile.StatusID + ", '" + profile.Nickname + "')";
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProfile(Profile profile)
        {
            try
            {
                string stmt = "UPDATE Profile SET statusId = '" + profile.StatusID + "', nickname = '" + profile.Nickname + "' WHERE profileID = " + profile.ProfileID;
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
