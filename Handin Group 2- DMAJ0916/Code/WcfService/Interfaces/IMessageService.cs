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
        [OperationContract(IsOneWay = true)]
        void JoinChat(int chatId, int profileId, string clientId);

        [OperationContract(IsOneWay = true)]
        void LeaveChat(int chatId, int profileId);

        [OperationContract(IsOneWay = true)]
        void InviteToChat(int chatId, string name);

        [OperationContract(IsOneWay = true)]
        void Writing(int chatId);

        [OperationContract(IsOneWay = true)]
        void CreateMessage(int profileId, string text, int chatId);

        [OperationContract(IsOneWay = true)]
        void DeleteMessage(int profileId, int id, int chatId);
    }

    public interface IMessageCallBack
    {
        [OperationContract(IsOneWay = true)]
        void WritingMessage(string clientId);

        [OperationContract(IsOneWay = true)]
        void AddMessage(Message message, string clientId);

        [OperationContract(IsOneWay = true)]
        void RemoveMessage(int id, string clientId);

        [OperationContract(IsOneWay = true)]
        void Invite(bool result);

        [OperationContract(IsOneWay = true)]
        void GetOnlineProfiles(List<Profile> profiles, string clientId);

        [OperationContract(IsOneWay = true)]
        void GetChat(Chat chat, string clientId);

        [OperationContract(IsOneWay = true)]
        void GetMessages(List<Message> messages, string clientId);

        [OperationContract(IsOneWay = true)]
        void Show(bool result, string clientId);
    }
}
