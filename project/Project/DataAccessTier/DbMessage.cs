using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace DataAccessTier
{
    public class DbMessage
    {
        private SqlConnection con = null;

        public DbMessage()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        public void CreateMessage(int profileId, String text, int chatId, SqlTransaction transaction)
        {
            string stmt = "INSERT INTO Activity (profileID, timeStamp) OUTPUT INSERTED.activityID values (@0, @1)";
            SqlCommand cmd = new SqlCommand(stmt, con, transaction);
            cmd.Parameters.AddWithValue("@0", profileId);
            cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                reader.Read();
                stmt = "INSERT INTO Text(activityID, message) OUTPUT INSERTED.textID values(@0, @1)";
                cmd = new SqlCommand(stmt, con, transaction);
                cmd.Parameters.AddWithValue("@0", Int32.Parse(reader["activityID"].ToString()));
                cmd.Parameters.AddWithValue("@1", text);
                reader.Close();
                reader = cmd.ExecuteReader();

                reader.Read();
                stmt = "INSERT INTO Message (textID, chatID) values (@0, @1)";
                cmd = new SqlCommand(stmt, con, transaction);
                cmd.Parameters.AddWithValue("@0", Int32.Parse(reader["textID"].ToString()));
                cmd.Parameters.AddWithValue("@1", chatId);
                reader.Close();
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                reader.Close();
                throw e;
            }
        }

        public Message GetMessage(int id)
        {
            string stmt = "SELECT Profile.nickname, " +
                                "Activity.activityID, " +
                                "Text.message, " +
                                "Activity.timeStamp " +
                            "FROM Profile " +
                            "INNER JOIN Activity " +
                                "on Profile.profileID = Activity.profileID " +
                            "INNER JOIN Text " +
                                "on Activity.activityID = Text.activityID " +
                            "INNER JOIN Message " +
                                "on Text.textID = Message.textID " +
                            "where Activity.activityID = @0";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0", id);
            SqlDataReader reader = cmd.ExecuteReader();
            Message message = null;
            if(reader.Read())
            {
                message = new Message(Int32.Parse(reader["activityID"].ToString()), reader["message"].ToString(), reader["nickname"].ToString(), Convert.ToDateTime(reader["timeStamp"].ToString()));
            }
            reader.Close();
            return message;
        }

        public List<Message> GetMessages(int chatId)
        {
            string stmt = "SELECT TOP(20) " +
                                "Profile.nickname, " +
                                "Activity.activityID, " +
                                "Text.message, " +
                                "Activity.timeStamp " +
                            "FROM Profile " +
                            "INNER JOIN Activity " +
                                "on Profile.profileID = Activity.profileID " +
                            "INNER JOIN Text " +
                                "on Activity.activityID = Text.activityID " +
                            "INNER JOIN Message " +
                                "on Text.textID = Message.textID " +
                            "where Message.chatID = @0 " +
                            "ORDER BY activityID DESC";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0",chatId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Message> messages = new List<Message>();
            while (reader.Read())
            {
                messages.Add(new Message(Int32.Parse(reader["activityID"].ToString()), reader["message"].ToString(), reader["nickname"].ToString(), Convert.ToDateTime(reader["timeStamp"].ToString())));
            }
            reader.Close();
            return messages;
        }

        public int DeleteMessage(int id)
        {
            string stmt = "DELETE FROM Activity WHERE activityID = @0";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.AddWithValue("@0", id);
            int rows =cmd.ExecuteNonQuery();
            return rows;
        }
    }
}

