using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IMessageCallBack))]
    public interface IMessageService
    {
        [OperationContract]
        bool JoinChat(int chatId, int profileId);

        [OperationContract]
        bool LeaveChat(int chatId, int profileId);

        [OperationContract]
        List<Profile> GetOnlineProfiles(int chatId);

        [OperationContract]
        Chat GetChat(int chatId);

        [OperationContract(IsOneWay = true)]
        void CreateMessage(int profileId, String text, int chatId);

        [OperationContract]
        List<Message> GetMessages(int chatId);

        [OperationContract(IsOneWay = true)]
        void DeleteMessage(int id, int chatId);
    }

    public interface IMessageCallBack
    {
        [OperationContract(IsOneWay = true)]
        void AddMessage(Message message);

        [OperationContract(IsOneWay = true)]
        void RemoveMessage(int id);
    }
}
