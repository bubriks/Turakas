using DataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbLogin
    {
        private SqlConnection con = null;

        public DbLogin()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        /// <summary>
        /// Checks if username and password exist in the database
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Returns loginID if succeded, -1 if there is no such loginInfo, -2 if sql exception and prints it in the console</returns>
        public int Authenticate(Login login)
        {
            try
            {
                string stmt = "SELECT loginID FROM Login WHERE username='" + login.Username + "' AND passwordHash=HASHBYTES('SHA2_512', '" + login.Password + "'+CAST(Salt AS NVARCHAR(36)))";
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
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
        /// <param name="login">New LoginInfo</param>
        /// <returns>Returns the ID assigned to the login by the database or -1 if it fails and prints error in console</returns>
        public int CreateLogin(Login login)
        {

        //    string stmtEmail = "SELECT * FROM Login WHERE email = '"+login.Email+"';";
        //    using (SqlCommand cmd = new SqlCommand(stmtEmail, con))
        //    {
        //        using (SqlDataReader readerEmail = cmd.ExecuteReader())
        //        {
        //            if (readerEmail.Read().ToString() != null)
        //            {
        //                throw new Exception("Email is already being used!");
        //            }
        //        }
        //    }
        //    string stmtUsername = "SELECT * FROM Login WHERE username = '" + login.Username + "';";
        //    using (SqlCommand cmd = new SqlCommand(stmtEmail, con))
        //    {
        //        using (SqlDataReader readerUsername = cmd.ExecuteReader())
        //        {
        //            if (readerUsername.Read().ToString() != null)
        //            {
        //                throw new Exception("Username is already being used!");
        //            }
        //        }
        //    }
                
                try
                {
                    string stmt1 = "DECLARE @salt UNIQUEIDENTIFIER=NEWID() INSERT INTO Login(username, salt, passwordHash, email)" +
                        "OUTPUT INSERTED.loginID values ('" + login.Username + "', @salt, HASHBYTES('SHA2_512', '" + login.Password + "'+CAST(@salt AS NVARCHAR(36))), '" + login.Email + "')";
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
        /// <param name="by">type by which the search should be done (1 = id, 2 = username, 3 = email)</param>
        /// <returns>Returns list of Login object and it's id</returns>
        public Login ReadLogin(string what, int by)
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
                default:
                    throw new Exception("'by' parameter must be either 1,2 or 3");
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(stmt, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        Login login1 = new Login
                        {
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            Email = reader["email"].ToString(),
                        };
                        login1.LoginId = reader.GetInt32(0);
                        return login1;
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        /// <summary>
        /// Updates LoginInfo
        /// </summary>
        /// <param name="id">The ID of the info you want to change</param>
        /// <param name="login">New LoginInfo</param>
        /// <returns>Returns true if succeded, false otherwise and prints error in console</returns>
        public bool UpdateLogin(int id, Login login)
        {
            try
            {
                string stmt = "DECLARE @salt UNIQUEIDENTIFIER=NEWID()" +
                    "UPDATE Login SET username = '" + login.Username + "', salt = @salt, passwordHash = HASHBYTES('SHA2_512', '" + login.Password + "'+CAST(@salt AS NVARCHAR(36))), email = '" + login.Email + "' WHERE loginID= " + id;
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
        public bool DeleteLogin(int id)
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
