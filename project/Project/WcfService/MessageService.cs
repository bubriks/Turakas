using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;

namespace WcfService
{
    public class MessageService: IMessageService
    {
        private static List<IMessageCallBack> clientList = new List<IMessageCallBack>();
        private IMessageController messageController = new MessageController();

        public void Register()
        {
            IMessageCallBack callback = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();
            clientList.Add(callback);
        }

        public void CreateMessage(int profileId, string text, int chatId)
        {
            Message message = messageController.CreateMessage(profileId, text, chatId);
            foreach(IMessageCallBack callback in clientList)
            {
                callback.CallBackMessage(message);
            }
        }

        public List<Message> GetMessages(int chatId)
        {
            return messageController.GetMessages(chatId);
        }

        public bool DeleteMessage(int id)
        {
            return messageController.DeleteMessage(id);
        }
    }
}
