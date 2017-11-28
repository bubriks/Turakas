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
        [OperationContract(IsOneWay = true)]
        void Online(int profileId);

        [OperationContract(IsOneWay = true)]
        void Offline(int profileId);

        [OperationContract(IsOneWay = true)]
        void SaveChat(int profileId, Chat chat);

        [OperationContract(IsOneWay = true)]
        void DeleteChat(int profileId, int id);

        [OperationContract]
        List<Chat> GetChatsByName(String name, int profileId);

        [OperationContract]
        List<Group> GetUsersGroups(int profileId);

        [OperationContract(IsOneWay = true)]
        void joinChatWhithGroup(int groupId, int chatId);

        [OperationContract(IsOneWay = true)]
        void RefreshConnection(int profileId);
    }

    public interface IChatCallBack
    {
        [OperationContract(IsOneWay = true)]
        void Notification(Chat chat);

        [OperationContract(IsOneWay = true)]
        void joinChat(int chatId);

        [OperationContract(IsOneWay = true)]
        void Refreshed();
    }
}
