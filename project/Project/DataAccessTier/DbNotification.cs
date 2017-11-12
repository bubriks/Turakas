using DataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbNotification
    {
        private DbConnection con = null;
        public DbNotification()
        {
            con = DbConnection.GetInstance();
        }

        /// <summary>
        /// Creates new notification for a given user
        /// </summary>
        /// <param name="notification">Notification object</param>
        /// <returns>Returns true if succesful</returns>
        public bool CreateNotification(Notification notification)
        {
            try
            {
                string stmt = "INSERT INTO Notifications (activityId, profileID) VALUES(" + notification.ActivityId + " " + notification.ProfileId + ");";

                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Reads all of the notifications for the given user
        /// </summary>
        /// <param name="profileId">wanted user</param>
        /// <returns>Returns a list of notifications</returns>
        public List<Notification> ReadNotification(int profileId)
        {
            List<Notification> notifications = new List<Notification>();
            try
            {
                string stmt = "SELECT * FROM Notifications WHERE profileId = " + profileId;

                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Notification notification = new Notification
                    {
                        ActivityId = reader.GetInt32(0),
                        ProfileId = reader.GetInt32(1),
                    };
                    notifications.Add(notification);
                }
                return notifications;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes a given notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns>Returns true if succesful</returns>
        public bool DeleteNotification(Notification notification)
        {
            try
            {
                string stmt = "DELETE FROM Notifications WHERE activityID = " + notification.ActivityId + " AND profileId = " + notification.ProfileId;
                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes all notifications of a given profile
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns>Returns true, if succesful</returns>
        public bool DeleteAllNotifications(int profileId)
        {
            try
            {
                string stmt = "DELETE FROM Notifications WHERE profileId = " + profileId;
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
