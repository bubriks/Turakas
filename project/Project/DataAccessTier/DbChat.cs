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
        private DbConnection con = null;

        public DbChat()
        {
            con = DbConnection.GetInstance();
        }

        public Chat CreateChat(Chat chat)
        {
            string stmt = "INSERT INTO Chat(name, type, nrOfUsers) OUTPUT INSERTED.chatID values (@0, @1, @2);";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", chat.Name);
            cmd.Parameters.AddWithValue("@1", Convert.ToInt32(chat.Type));
            cmd.Parameters.AddWithValue("@2", chat.MaxNrOfUsers);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                chat.Id = Int32.Parse(reader["chatID"].ToString());
            }
            reader.Close();
            return chat;
        }

        public Chat GetChat(int id)
        {
            string stmt = "Select name, type, nrOfUsers FROM Chat where chatId = @0";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", id);
            SqlDataReader reader = cmd.ExecuteReader();
            Chat chat = null;
            if(reader.Read())
            {
                chat = new Chat
                {
                    Id = id,
                    Name = reader["name"].ToString(),
                    Type = (bool)reader["type"],
                    MaxNrOfUsers = Int32.Parse(reader["nrOfUsers"].ToString())
                };
            }
            reader.Close();
            return chat;
        }

        public Chat UpdateChat(Chat chat)
        {
            string stmt = "UPDATE Chat SET name = @0, type = @1, nrOfUsers= @2 WHERE chatID= @3";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", chat.Name);
            cmd.Parameters.AddWithValue("@1", Convert.ToInt32(chat.Type));
            cmd.Parameters.AddWithValue("@2", chat.MaxNrOfUsers);
            cmd.Parameters.AddWithValue("@3", chat.Id);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return chat;
            }
            return null;
        }

        public List<Chat> GetChatsByName(String name)
        {
            string stmt = "Select chatID, name, type, nrOfUsers FROM Chat where name like '%'+@0+'%';";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", name);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Chat> chats = new List<Chat>();
            while (reader.Read())
            {
                Chat chat = new Chat
                {
                    Id = Int32.Parse(reader["chatID"].ToString()),
                    Name = reader["name"].ToString(),
                    Type = (bool)reader["type"],
                    MaxNrOfUsers = Int32.Parse(reader["nrOfUsers"].ToString())
                };
                chats.Add(chat);
            }
            reader.Close();
            return chats;
        }

        public int DeleteChat(int id)
        {
            string stmt = "DELETE FROM Chat WHERE chatID = @0";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", id);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }
    }
}
