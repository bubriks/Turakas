using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        public bool CreateActivity(int profileId)
        {
            try
            {
                string stmt = "INSERT INTO Activity (profileID, timeStamp) VALUES(" + profileId + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ");";

                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Finds all the activities, a profile has done
        /// </summary>
        /// <param name="profileId">The Id of the profile you wish to seach for</param>
        /// <note>Throws exceptions, if any</note>
        /// <returns>Returns a list of activity Ids</returns>
        public List<int> FindActivities(int profileId)
        {
            List<int> activities = new List<int>();
            try
            {
                string stmt = "SELECT * FROM Activity WHERE profileId = " + profileId;

                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    activities.Add(reader.GetInt32(0));
                }
                return activities;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes a specific activity
        /// </summary>
        /// <param name="activityId">The Id of the activity you wish to delete</param>
        /// <note>Can be used in combination with FindActivities, to delete a profiles all activities; Throws exceptions, if any</note>
        /// <returns>Returns true, if succesfull</returns>
        public bool DeleteActivity(int activityId)
        {
            try
            {
                string stmt = "DELETE FROM Activity WHERE activityID = " + activityId;
                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
