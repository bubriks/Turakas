using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;

namespace WcfService
{
    public class NotificationService: INotificationService
    {
        INotificationController notificationController = new NotificationController();

        public bool CreateNotification(Notification notification)
        {
            return notificationController.CreateNotification(notification);
        }

        public List<Notification> ReadNotification(int profileId)
        {
            return notificationController.ReadNotification(profileId);
        }

        public bool DeleteNotification(Notification notification)
        {
            return notificationController.DeleteNotification(notification);
        }

        public bool DeleteAllNotifications(int profileId)
        {
            return notificationController.DeleteAllNotifications(profileId); 
        }
    }
}
