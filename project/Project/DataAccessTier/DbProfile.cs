using DataTier;
using System;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbProfile
    {
        private SqlConnection con = null;

        public DbProfile()
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
                    " VALUES (" + profile.ProfileID + ", " + profile.StatusID + ", '" + profile.Nickname + "');";
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    cmd.ExecuteNonQuery();
                }
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
        /// <param name="what">string of what you are looking for</param>
        /// <param name="by">type by which the search should be done (1 = id, 2 = nickname)</param>
        /// <returns>Returns null if there is no such profile, and prints error in console, if any</returns>
        public Profile ReadProfile(string what, int by)
        {
            string stmt;
            switch (by)
            {
                case 1:
                    stmt = "SELECT * FROM Profile where profileID = " + what;
                    break;
                case 2:
                    stmt = "SELECT * FROM Profile WHERE nickname = '" + what+"';";
                    break;
                default:
                    throw new Exception("'by' parameter must be either 1 or 2");
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Profile profile = new Profile
                            {
                                ProfileID = reader.GetInt32(0),
                                StatusID = reader.GetInt32(1),
                                Nickname = reader.GetString(2),
                            };
                            reader.Close();
                            return profile;
                        }
                        else
                        {
                            return null;
                        }
                    }
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
            string stmt = "UPDATE Profile SET ";
            if (profile.StatusID != 0 && profile.ProfileID != 0)
                stmt += "statusID = " + profile.StatusID + ", " + "statusID = " + profile.StatusID + " ";
            else
            if (profile.StatusID != 0 && profile.Nickname != null)
                stmt += "statusID = " + profile.StatusID + " " + " nickname = '" + profile.Nickname + "' ";
            else
            {
                if (profile.StatusID != 0)
                    stmt += "statusID = " + profile.StatusID + " ";
                if (profile.ProfileID != 0)
                    stmt += " profileID = " + profile.ProfileID + " ";
                if (profile.Nickname != null)
                    stmt += " nickname = '" + profile.Nickname + "' ";
            }
            try
            {
                stmt += " WHERE profileID = " + profile.ProfileID + ";";
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    cmd.ExecuteNonQuery();
                }
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
