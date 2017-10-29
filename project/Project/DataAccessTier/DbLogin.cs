using DataTier;
using System;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DBLogin
    {
        private SqlConnection con = null;

        public DBLogin()
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
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
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
        public int CreateLogin(Login login, SqlTransaction ts)
        {
            try
            {
                string stmt = "DECLARE @salt UNIQUEIDENTIFIER=NEWID() INSERT INTO Login(username, salt, passwordHash, email)" +
                    "OUTPUT INSERTED.loginID values ('" + login.Username + "', @salt, HASHBYTES('SHA2_512', '" + login.Password + "'+CAST(@salt AS NVARCHAR(36))), '" + login.Email + "')";
                SqlDataReader reader = new SqlCommand(stmt, con, ts).ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        /// <summary>
        /// Find loginInfo by ID
        /// </summary>
        /// <param name="id">id of info you want to find</param>
        /// <returns>Returns Login object</returns>
        public Login ReadLogin(int loginId)
        {
            try
            {
                string stmt = "SELECT * FROM Login WHERE loginID = " + loginId;
                SqlDataReader reader = new SqlCommand(stmt, con).ExecuteReader();
                reader.Read();
                return new Login(reader.GetString(0), reader.GetString(1), reader.GetString(2));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
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
