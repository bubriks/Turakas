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
        /// <returns>Returns activityId succesfull</returns>
        public int CreateActivity(int profileId)
        {
            string stmt = "INSERT INTO Activity (profileID, timeStamp) OUTPUT INSERTED.activityID VALUES(@0, @1);";

            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", profileId);
                cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
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
        /// <param name="id">choice</param>
        /// <param name="by">1 = profileId, 2 = activityId</param>
        /// <returns>returns activity if values inserted are correct and there is this activity in database</returns>
        public Activity ReadActivity(int id, int by)
        {
            string stmt;
            Activity activity = null;
            if (by == 1)
                stmt = "SELECT * FROM Activity WHERE activityId = @0";
            else
                stmt = "SELECT * FROM Activity WHERE profileId = @0";

            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
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
        /// deletes activity if the action is done by creator
        /// </summary>
        /// <param name="profileId">ProfileId inserted here</param>
        /// <param name="id">ActivityId inserted here</param>
        /// <returns>How many rows have been changed</returns>
        public int DeleteActivity(int profileId, int id)
        {
            string stmt = " if (select profileID from Activity where activityId = @0) = @1 " +
                            " DELETE FROM Activity WHERE activityID = @0; ";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", id);
                cmd.Parameters.AddWithValue("@1", profileId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}