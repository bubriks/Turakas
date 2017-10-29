using DataTier;
using System;
using System.Data.SqlClient;

namespace DataAccessTier
{
    class DBProfile
    {
        private SqlConnection con = null;

        public DBProfile()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        /// <summary>
        /// Creates new Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>Returns true if succeded, false otherwise and prints error in console</returns>
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Returns Profile
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns>Returns null if there is no such profile, and prints error in console, if any</returns>
        public Profile ReadProfile(int profileId)
        {
            try
            {
                string stmt = "SELECT * FROM Profile where profileID = " + profileId;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        /// <summary>
        /// Updates profile info
        /// </summary>
        /// <param name="profileId">The ID of the profile you want to delete</param>
        /// <param name="profile">New Profile Info</param>
        /// <returns> Returns true if succeded, false otherwise and prints error in console</returns>
        public bool UpdateProfile(int profileId, Profile profile)
        {
            try
            {
                string stmt = "UPDATE Profile SET statusId = '" + profile.StatusID + "', nickname = '" + profile.Nickname + "' WHERE profileID = " + profile.ProfileID;
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
