using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataTier;

namespace DataAccessTier
{
    public class DbMessage
    {
        private DbConnection con = null;

        public DbMessage()
        {
            con = DbConnection.GetInstance();
        }

        public Message CreateMessage(int id, String text, int chatId)
        {
            string stmt =" INSERT INTO Message(activityID, chatActivityID, message) values(@0, @1, @2); " +

            " SELECT " +
                " Profile.nickname, " +
                " Activity.activityID, " +
                " Message.message, " +
                " Activity.timeStamp " +
                " FROM Profile " +
            " INNER JOIN Activity " +
                " on Profile.profileID = Activity.profileID " +
            " INNER JOIN Message " +
                " on Activity.activityID = Message.activityID " +
            " where Activity.activityID = @0;";

            Message message = null;
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", id);
                cmd.Parameters.AddWithValue("@1", chatId);
                cmd.Parameters.AddWithValue("@2", text);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        message = new Message
                        {
                            Id = Int32.Parse(reader["activityID"].ToString()),
                            Text = reader["message"].ToString(),
                            Creator = reader["nickname"].ToString(),
                            CreatorId = id,
                            Time = Convert.ToDateTime(reader["timeStamp"].ToString())
                        };
                    }
                    return message;
                }
            }
        }

        public List<Message> GetMessages(int chatId)
        {
            string stmt = " SELECT " +
                            " Profile.nickname, " +
                            " Profile.profileID, " +
                            " Activity.activityID, " +
                            " Message.message, " +
                            " Activity.timeStamp " +
                        " FROM Profile " +
                        " INNER JOIN Activity " +
                            " on Profile.profileID = Activity.profileID " +
                        " INNER JOIN Message " +
                            " on Activity.activityID = Message.activityID " +
                        " where Message.chatActivityID = @0 ";
            List<Message> messages = new List<Message>();
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", chatId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Message message = new Message
                        {
                            Id = Int32.Parse(reader["activityID"].ToString()),
                            Text = reader["message"].ToString(),
                            Creator = reader["nickname"].ToString(),
                            CreatorId = Int32.Parse(reader["profileID"].ToString()),
                            Time = Convert.ToDateTime(reader["timeStamp"].ToString())
                        };
                        messages.Add(message);
                    }
                }
            }
            return messages;
        }
    }
}

