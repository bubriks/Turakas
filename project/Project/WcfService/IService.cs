using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using System.Collections;

namespace WcfService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Chat CreateChat(Chat chat, int personId);

        [OperationContract]
        Chat GetChat(int id);

        [OperationContract]
        ArrayList GetChatsByName(String name);

        [OperationContract]
        bool UpdateChat(Chat chat);

        [OperationContract]
        bool DeleteChat(int id);

        [OperationContract]
        ArrayList GetPersonsInChat(int chatId);

        [OperationContract]
        bool AddPersonToChat(int chatId, int personId);

        [OperationContract]
        bool RemovePersonFromChat(int chatId, int personId);
    }
}
