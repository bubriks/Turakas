using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract]
    public interface INotificationService
    {
        [OperationContract]
        bool CreateNotification(Notification notification);

        [OperationContract]
        List<Notification> ReadNotification(int profileId);

        [OperationContract]
        bool DeleteNotification(Notification notification);

        [OperationContract]
        bool DeleteAllNotifications(int profileId);
    }
}
