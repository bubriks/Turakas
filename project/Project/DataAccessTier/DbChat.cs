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
        private SqlTransaction trans = null;

        public DbChat()
        {
            con = DbConnection.GetInstance().GetConnection();
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

        public Chat AddChat(Chat chat)
        {
            try
            {
                string stmt = "INSERT INTO Chat(name, type) OUTPUT INSERTED.chatID values ('"+ chat.Name + "', "+ Convert.ToInt32(chat.Type)+")";
                SqlDataReader reader = new SqlCommand(stmt, con).ExecuteReader();
                reader.Read();
                chat.Id = reader.GetInt32(0);
                return chat;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateChat(Chat chat)
        {
            try
            {
                trans = con.BeginTransaction();
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trans;
                cmd.CommandText = "UPDATE Chat SET name = '" + chat.Name + "', type = '" + Convert.ToInt32(chat.Type) + "' WHERE chatID= " + chat.Id;
                cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception)
            {
                trans.Rollback();
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
