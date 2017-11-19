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
        [OperationContract(IsOneWay = true)]
        void SaveChat(Chat chat);

        [OperationContract(IsOneWay = true)]
        void DeleteChat(int id);

        [OperationContract]
        List<Chat> GetChatsByName(String name, int profileId);
    }
}
