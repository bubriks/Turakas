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
        public int CreateActivity(int profileId, SqlTransaction transaction)
        {
            string stmt = "INSERT INTO Activity (profileID, timeStamp) OUTPUT INSERTED.activityID VALUES(@0, @1);";

            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), transaction))
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
        /// deletes activity if the action is done by creator
        /// </summary>
        /// <param name="profileId">ProfileId inserted here</param>
        /// <param name="id">ActivityId inserted here</param>
        /// <returns>How many rows have been changed</returns>
        public int DeleteActivity(int profileId, int id, SqlTransaction transaction)
        {
            string stmt = " if (select profileID from Activity where activityId = @0) = @1 " +
                            " DELETE FROM Activity WHERE activityID = @0; ";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), transaction))
            {
                cmd.Parameters.AddWithValue("@0", id);
                cmd.Parameters.AddWithValue("@1", profileId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}