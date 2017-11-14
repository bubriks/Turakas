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
        void SaveChat(Chat chat);

        [OperationContract]
        List<Chat> GetChatsByName(String name);

        [OperationContract]
        void DeleteChat(int id);
    }
}
