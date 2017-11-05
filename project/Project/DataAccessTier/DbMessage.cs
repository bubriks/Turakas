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
        private DbConnection con = null;

        public DbMessage()
        {
            con = DbConnection.GetInstance();
        }

        public int CreateMessage(int profileId, String text, int chatId)
        {
            string stmt = "DECLARE @id int;" +
                "INSERT INTO Activity (profileID, timeStamp) VALUES(@0, @1);" +
                "SET @id = @@IDENTITY;" +

                "INSERT INTO Text (activityID, message) values(@id, @2);" +
                "SET @id = @@IDENTITY;" +

                "INSERT INTO Message (textID, chatID) values (@id, @3);";

            using (SqlCommand cmd = con.GetConnection().CreateCommand())
            {
                cmd.CommandText = stmt;
                cmd.Parameters.AddWithValue("@0", profileId);
                cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                cmd.Parameters.AddWithValue("@2", text);
                cmd.Parameters.AddWithValue("@3", chatId);
                cmd.Transaction = con.GetTransaction();
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
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
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
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
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", id);
            int rows =cmd.ExecuteNonQuery();
            return rows;
        }
    }
}

