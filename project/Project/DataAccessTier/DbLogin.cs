using DataTier;
using System;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbLogin
    {
        private DbConnection con= null;

        public DbLogin()
        {
            con = DbConnection.GetInstance();
        }

        public Tuple<Login, int> Login(Login login)
        {
            try
            {
                string stmt = "SELECT * FROM Login where username= '"+ login.Username + "' AND passwordHash=HASHBYTES('SHA2_512', '" + login.Password + "'+CAST(Salt AS NVARCHAR(36)))";
                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    login.Email = reader.GetString(4);
                    int id = reader.GetInt32(0);
                    reader.Close();
                    return Tuple.Create(login, id);
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

        public int CreateLogin(Login login)
        {
            try
            {
                string stmt = "DECLARE @salt UNIQUEIDENTIFIER=NEWID() INSERT INTO Login(username, salt, passwordHash, email)" +
                    "OUTPUT INSERTED.loginID values ('" + login.Username + "', @salt, HASHBYTES('SHA2_512', '" + login.Password + "'+CAST(@salt AS NVARCHAR(36))), '" + login.Email + "')";
                SqlDataReader reader = new SqlCommand(stmt, con.GetConnection()).ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool UpdateLogin(int id, Login login)
        {
            try
            {
                string stmt = "DECLARE @salt UNIQUEIDENTIFIER=NEWID()" +
                    "UPDATE Login SET username = '" + login.Username + "', salt = @salt, passwordHash = HASHBYTES('SHA2_512', '" + login.Password + "'+CAST(@salt AS NVARCHAR(36))), email = '" + login.Email + "' WHERE loginID= " + id;
                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLogin(int id)
        {
            try
            {
                string stmt = "DELETE FROM Login WHERE loginID = " + id;
                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
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
