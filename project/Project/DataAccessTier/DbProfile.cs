using DataTier;
using System;
using System.Collections.Generic;
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
        /// Checks if username and password exist in the database
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>Returns loginID if succeded, -1 if there is no such loginInfo, -2 if sql exception and prints it in the console</returns>
        public int Authenticate(Profile profile)
        {
            try
            {
                string stmt = "SELECT loginID FROM Login WHERE username='" + profile.Username + "' AND passwordHash=HASHBYTES('SHA2_512', '" + profile.Password + "'+CAST(Salt AS NVARCHAR(36)))";
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            int id = Int32.Parse(reader["loginID"].ToString());
                            return id;
                        }
                    }
                }
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -2;
            }
        }

        /// <summary>
        /// Creates new LoginInfo
        /// </summary>
        /// <param name="profile">New LoginInfo</param>
        /// <returns>Returns the ID assigned to the login by the database or -1 if it fails and prints error in console</returns>
        public int CreateProfile(Profile profile)
        {
                try
                {
                    string stmt1 = "DECLARE @salt UNIQUEIDENTIFIER=NEWID() INSERT INTO Login(username, salt, passwordHash, email, nickname)" +
                        "OUTPUT INSERTED.loginID values ('" + profile.Username + "', @salt, HASHBYTES('SHA2_512', '" + profile.Password + "'+CAST(@salt AS NVARCHAR(36))), '" + profile.Email + "', '" + profile.Nickname + "' );";
                    using (SqlCommand cmd = new SqlCommand(stmt1, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            int id = reader.GetInt32(0);
                            return id;
                        }
                }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            return -1;
        }

        /// <summary>
        /// Find loginInfo by multiple parameters
        /// </summary>
        /// <param name="what">string of what you are looking for</param>
        /// <param name="by">type by which the search should be done (1 = id, 2 = username, 3 = email, nickname = 4)</param>
        /// <returns>Returns list of Login object and it's id</returns>
        public Profile ReadProfile(string what, int by)
        {
            string stmt;

            switch(by)
            {
                case 1:
                    stmt = "SELECT * FROM Login WHERE loginId = " + what;
                    break;
                case 2:
                    stmt = "SELECT * FROM Login WHERE username = '" + what + "';";
                    break;
                case 3:
                    stmt = "SELECT * FROM Login WHERE email = '" + what + "';";
                    break;
                case 4:
                    stmt = "SELECT * FROM Login WHERE nickname = '" + what + "';";
                    break;
                default:
                    throw new Exception("'by' parameter must be either 1, 2, 3 or 4");
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            Profile login1 = new Profile
                            {
                                ProfileID = Int32.Parse(reader["loginID"].ToString()),
                                Username = reader["username"].ToString(),
                                Email = reader["email"].ToString(),
                                Nickname = reader["nickname"].ToString(),
                            };
                            return login1;
                        }
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Updates ProfileInfo
        /// </summary>
        /// <param name="id">The ID of the info you want to change</param>
        /// <param name="profile">New LoginInfo</param>
        /// <returns>Returns true if succeded, false otherwise and prints error in console</returns>
        public bool UpdateProfile(int id, Profile profile)
        {
            try
            {
                string stmt = "DECLARE @salt UNIQUEIDENTIFIER=NEWID()" +
                    "UPDATE Login SET username = '" + profile.Username + "', salt = @salt, passwordHash = HASHBYTES('SHA2_512', '" + profile.Password + "'+CAST(@salt AS NVARCHAR(36))), email = '" + profile.Email + "', nickname = '" + profile.Nickname + "' WHERE loginID= " + id;
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Deletes LoginInfo
        /// !!! Deleteing Login, WILL ALSO DELETE LINKED PROFILE AND ALL THE ACTIONS THAT PROFILE HAS MADE
        /// </summary>
        /// <param name="id">ID of info you want to delete</param>
        /// <returns>Returns true if succedes, false otherwise and prints error in console</returns>
        public bool DeleteProfile(int id)
        {
            try
            {
                string stmt = "DELETE FROM Login WHERE loginID = " + id;
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
