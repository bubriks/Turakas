using DataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public class DbChat
    {
        private SqlConnection con = null;

        public DbChat()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        public Chat CreateChat(Chat chat)
        {
            try
            {
                string stmt = "INSERT INTO Chat(name, type) OUTPUT INSERTED.chatID values ('" + chat.Name + "', " + Convert.ToInt32(chat.Type) + ")";
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                chat.Id = Int32.Parse(reader["chatID"].ToString());
                return chat;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Chat GetChat(int id)
        {
            try
            {
                string stmt = "SELECT * FROM Chat where chatID = " + id;
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Chat chat = new Chat(reader.GetInt32(0), reader.GetString(1), (bool)reader.GetSqlBoolean(2));
                    reader.Close();
                    return chat;
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

        public bool UpdateChat(Chat chat)
        {
            try
            {
                string stmt = "UPDATE Chat SET name = '" + chat.Name + "', type = '" + Convert.ToInt32(chat.Type) + "' WHERE chatID= " + chat.Id;
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteChat(int id)
        {
            try
            {
                string stmt = "DELETE FROM Chat WHERE chatID = " + id;
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
