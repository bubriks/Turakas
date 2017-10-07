using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DbChat
    {
        private DbConnection con;

        public DbChat()
        {
            con = DbConnection.GetInstance();
        }

        public void SendText(string text)
        {
            string stmt = "INSERT INTO Chat(text) VALUES('" + text + "')";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public String GetText()
        {
            string stmt = "Select * from chat";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            String message = "\n";
            while (reader.Read())
            {
                message += reader.GetString(0) + "\n";
            }
            return message;
        }
    }
}
