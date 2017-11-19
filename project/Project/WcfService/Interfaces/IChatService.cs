using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IChatCallBack))]
    public interface IChatService
    {
        [OperationContract]
        bool Online(int profileId);

        [OperationContract]
        bool Offline(int profileId);

        [OperationContract(IsOneWay = true)]
        void SaveChat(Chat chat);

        [OperationContract(IsOneWay = true)]
        void DeleteChat(int id);

        [OperationContract]
        List<Chat> GetChatsByName(String name, int profileId);
    }

    public interface IChatCallBack
    {
        [OperationContract(IsOneWay = true)]
        void Notification(Chat chat);
    }
}
