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
    public interface IMessageService
    {
        [OperationContract]
        bool CreateMessage(int profileId, String text, int chatId);

        [OperationContract]
        List<Message> GetMessages(int chatId);

        [OperationContract]
        bool DeleteMessage(int id);
    }
}
