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
    public interface IChatService
    {
        [OperationContract]
        Chat CreateChat(Chat chat, int profileId);

        [OperationContract]
        List<Chat> GetChatsByName(String name);

        [OperationContract]
        bool UpdateChat(Chat chat);

        [OperationContract]
        bool DeleteChat(int id);

        [OperationContract]
        List<Chat> GetPersonsChats(int profileId);

        [OperationContract]
        List<Profile> GetPersonsInChat(int chatId);

        [OperationContract]
        bool AddPersonToChat(int chatId, int profileId);

        [OperationContract]
        bool RemovePersonFromChat(int chatId, int profileId);
    }
}
