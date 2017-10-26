using System;
using System.Collections;
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

        public void CreateMessage(int profileId, String text, int chatId)
        {
            string stmt = "INSERT INTO Activity (profileID, timeStamp) OUTPUT INSERTED.activityID values (" + profileId + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')";
            SqlDataReader reader = new SqlCommand(stmt, con).ExecuteReader();
            reader.Read();

            stmt = "INSERT INTO Text(activityID, message) OUTPUT INSERTED.textID values(" + Int32.Parse(reader["activityID"].ToString()) + ", (select cast('" + text + "' as varbinary(max))))";
            reader.Close();
            reader = new SqlCommand(stmt, con).ExecuteReader();
            reader.Read();

            stmt = "INSERT INTO Message (textID, chatID) values (" + Int32.Parse(reader["textID"].ToString()) + ", " + chatId + ")";
            reader.Close();
            new SqlCommand(stmt, con).ExecuteNonQuery();
        }

        public ArrayList GetMessages(int chatId)
        {
            string stmt = "SELECT " +
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
                            "where Message.chatID = " + chatId;
            SqlCommand cmd = new SqlCommand(stmt, con);
            SqlDataReader reader = cmd.ExecuteReader();
            ArrayList messages = new ArrayList();
            while (reader.Read())
            {
                messages.Add(new Message(Int32.Parse(reader["activityID"].ToString()), Encoding.UTF8.GetString((byte[])reader["message"]), reader["nickname"].ToString(), Convert.ToDateTime(reader["timeStamp"].ToString())));
            }
            reader.Close();
            return messages;
        }

        public void DeleteMessage(int id)
        {
            string stmt = "DELETE FROM Activity WHERE activityID = " + id;
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.ExecuteNonQuery();
        }
    }
}

