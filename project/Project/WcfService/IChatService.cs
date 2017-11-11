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
    }
}
