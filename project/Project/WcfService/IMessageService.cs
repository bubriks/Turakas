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
        void Register();

        [OperationContract]
        void CreateMessage(int profileId, String text, int chatId);

        [OperationContract]
        List<Message> GetMessages(int chatId);

        [OperationContract]
        bool DeleteMessage(int id);
    }

    public interface IMessageCallBack
    {
        [OperationContract(IsOneWay = true)]
        void CallBackMessage(Message message);
    }
}
