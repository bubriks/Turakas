using DataTier;
using System.Collections.Generic;

namespace BusinessTier
{
    public interface INotificationController
    {
        /// <summary>
        /// Creates new notification for a given user
        /// </summary>
        /// <param name="notification">Notification object</param>
        /// <returns>Returns true if succesful</returns>
        bool CreateNotification(Notification notification);

        /// <summary>
        /// Reads all of the notifications for the given user
        /// </summary>
        /// <param name="profileId">wanted user</param>
        /// <returns>Returns a list of notifications</returns>
        List<Notification> ReadNotification(int profileId);

        /// <summary>
        /// Deletes a given notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns>Returns true if succesful</returns>
        bool DeleteNotification(Notification notification);

        /// <summary>
        /// Deletes all notifications of a given profile
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns>Returns true, if succesful</returns>
        bool DeleteAllNotifications(int profileId);
    }
}
