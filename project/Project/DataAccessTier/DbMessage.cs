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

        public Message CreateMessage(int profileId, String text, int chatId)
        {
            string stmt = " DECLARE @activityID int; " +

            " INSERT INTO Activity(profileID, timeStamp) VALUES(@0, @1); " +
            " SET @activityID = @@IDENTITY;" +

            " INSERT INTO Message(activityID, chatActivityID, message) values(@activityID, @3, @2); " +

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
            " where Activity.activityID = @activityID ";

            Message message = null;
            SqlCommand cmd = con.GetConnection().CreateCommand();
            cmd.CommandText = stmt;
            cmd.Parameters.AddWithValue("@0", profileId);
            cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@2", text);
            cmd.Parameters.AddWithValue("@3", chatId);
            cmd.Transaction = con.GetTransaction();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                message = new Message
                {
                    Id = Int32.Parse(reader["activityID"].ToString()),
                    Text = reader["message"].ToString(),
                    Creator = reader["nickname"].ToString(),
                    CreatorId = profileId,
                    Time = Convert.ToDateTime(reader["timeStamp"].ToString())
                };
            }
            reader.Close();
            return message;
        }
        
        public List<Message> GetMessages(int chatId)
        {
            string stmt = " SELECT " +
                            " Profile.nickname, " +
                            " Profile.profileID, " +
                            " Activity.activityID, " +
                            " Message.message," +
                            " Activity.timeStamp" +
                        " FROM Profile" +
                        " INNER JOIN Activity" +
                            " on Profile.profileID = Activity.profileID" +
                        " INNER JOIN Message" +
                            " on Activity.activityID = Message.activityID" +
                        " where Message.chatActivityID = @0";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", chatId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Message> messages = new List<Message>();
            while (reader.Read())
            {
                Message message = new Message
                {
                    Id = Int32.Parse(reader["activityID"].ToString()),
                    Text = reader["message"].ToString(),
                    Creator = reader["nickname"].ToString(),
                    CreatorId = Int32.Parse(reader["loginID"].ToString()),
                    Time = Convert.ToDateTime(reader["timeStamp"].ToString())
                };
                messages.Add(message);
            }
            reader.Close();
            return messages;
        }

        public int DeleteMessage(int id)
        {
            string stmt = "DELETE FROM Activity WHERE activityID = @0 ";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", id);
            int rows =cmd.ExecuteNonQuery();
            return rows;
        }
    }
}

