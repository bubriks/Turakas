using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataTier;

namespace DataAccessTier
{
    public class DbActivity
    {
        private DbConnection con = null;
        public DbActivity()
        {
            con = DbConnection.GetInstance();
        }

        /// <summary>
        /// Creates Activity related to the profile, with current time, timestamp.
        /// </summary>
        /// <param name="profileId">The Id of the profile that made the activity</param>
        /// <note>Throws any occured exception</note>
        /// <returns>Returns true, if succesfull</returns>
        public int CreateActivity(int profileId)
        {
            string stmt = "OUTPUT INSERT INTO Activity (profileID, timeStamp) OUTPUT INSERTED.activityID VALUES(@0, @1);";

            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@0", profileId);
                cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }

        /// <summary>
        /// Returns Activity Object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="by">1 = profileId, 2 = activityId</param>
        /// <returns></returns>
        public Activity ReadActivity(int id, int by)
        {
            string stmt;
            Activity activity = null;
            if (by == 1)
                stmt = "SELECT * FROM Activity WHERE activityId = @0";
            else
                stmt = "SELECT * FROM Activity WHERE profileId = @0";

            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@0", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        activity = new Activity
                        {
                            ActivityId = Int32.Parse(reader["activityID"].ToString()),
                            ProfileId = Int32.Parse(reader["profileID"].ToString()),
                            TimeStamp = (DateTime)reader["timestamp"],
                        };
                }
                return activity;
            }
        }

        /// <summary>
        /// Deletes a specific activity
        /// </summary>
        /// <param name="activityId">The Id of the activity you wish to delete</param>
        /// <note>Can be used in combination with FindActivities, to delete a profiles all activities; Throws exceptions, if any</note>
        /// <returns>Returns true, if succesfull</returns>
        public int DeleteActivity(int activityId)
        {
            string stmt = "DELETE FROM Activity WHERE activityID = @0";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@0", activityId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}