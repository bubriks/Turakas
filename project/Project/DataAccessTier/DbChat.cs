using DataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbChat
    {
        private DbConnection con = null;

        public DbChat()
        {
            con = DbConnection.GetInstance();
        }

        public int CreateChat(Chat chat)
        {
            string stmt ="INSERT INTO Chat(activityID, name, type, nrOfUsers) values (@0, @1, @2, @3);";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", chat.ActivityId);
                cmd.Parameters.AddWithValue("@1", chat.Name);
                cmd.Parameters.AddWithValue("@2", Convert.ToInt32(chat.Type));
                cmd.Parameters.AddWithValue("@3", chat.MaxNrOfUsers);
                return cmd.ExecuteNonQuery();
            }
        }

        public Chat GetChat(int id)
        {
            string stmt = "SELECT " +
                            " Profile.profileID, " +
                            " timeStamp, " +
                            " name, " +
                            " type, " +
                            " nrOfUsers " +
                        " FROM Profile " +
                        " INNER JOIN Activity " +
                            " on Profile.profileID = Activity.profileID " +
                        " INNER JOIN Chat " +
                            " on Activity.activityID = chat.activityID " +
                        " where Activity.activityID = @0 ;";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Chat chat = null;
                    if (reader.Read())
                    {
                        chat = new Chat
                        {
                            ActivityId = id,
                            ProfileId = Int32.Parse(reader["profileID"].ToString()),
                            TimeStamp = Convert.ToDateTime(reader["timeStamp"].ToString()),
                            Name = reader["name"].ToString(),
                            Type = (bool)reader["type"],
                            MaxNrOfUsers = Int32.Parse(reader["nrOfUsers"].ToString())
                        };
                    }
                    return chat;
                }
            }
        }

        public int UpdateChat(Chat chat)
        {
            string stmt = "UPDATE Chat SET name = @0, type = @1, nrOfUsers= @2 WHERE activityID= @3;";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", chat.Name);
                cmd.Parameters.AddWithValue("@1", Convert.ToInt32(chat.Type));
                cmd.Parameters.AddWithValue("@2", chat.MaxNrOfUsers);
                cmd.Parameters.AddWithValue("@3", chat.ActivityId);
            return cmd.ExecuteNonQuery();
            }
        }

        public List<Chat> GetChatsByName(string name, int profileId)
        {
            string stmt = " SELECT " +
                            " Profile.profileID, " +
                            " timeStamp, " +
                            " Activity.activityID, " +
                            " name, " +
                            " type, " +
                            " nrOfUsers " +
                        " FROM Chat " +
                        " INNER JOIN Activity " +
                            " on Chat.activityID = Activity.activityID " +
                        " INNER JOIN Profile " +
                            " on Activity.profileID = Profile.profileID " +
                        " where name like '%' +@0+ '%' AND type = 1  OR Profile.profileID = @1; ";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", name);
                cmd.Parameters.AddWithValue("@1", profileId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Chat> chats = new List<Chat>();
                    while (reader.Read())
                    {
                        Chat chat = new Chat
                        {
                            ActivityId = Int32.Parse(reader["activityID"].ToString()),
                            ProfileId = Int32.Parse(reader["profileID"].ToString()),
                            TimeStamp = Convert.ToDateTime(reader["timeStamp"].ToString()),
                            Name = reader["name"].ToString(),
                            Type = (bool)reader["type"],
                            MaxNrOfUsers = Int32.Parse(reader["nrOfUsers"].ToString())
                        };
                        chats.Add(chat);
                    }
                    return chats;
                }
            }
        }
    }
}
