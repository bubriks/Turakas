using System;
using System.Collections.Generic;
using DataAccessTier;
using DataTier;

namespace BusinessTier
{
    public class NotificationController : INotificationController
    {
        DbNotification dbNotification;
        public NotificationController()
        {
            dbNotification = new DbNotification();
        }


        public bool CreateNotification(Notification notification)
        {
            return dbNotification.CreateNotification(notification);
        }
        public List<Notification> ReadNotification(int profileId)
        {
            return dbNotification.ReadNotification(profileId);
        }
        public bool DeleteNotification(Notification notification)
        {
            return dbNotification.DeleteNotification(notification);
        }
        public bool DeleteAllNotifications(int profileId)
        {
            return dbNotification.DeleteAllNotifications(profileId);
        }


    }
}
