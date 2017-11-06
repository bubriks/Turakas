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
        IMessageController messageController = new MessageController();
        private static List<IMessageCallBack> clientList = new List<IMessageCallBack>();
        private IMessageCallBack callback = null;

        public void Register()
        {
            callback = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();
            clientList.Add(callback);
        }

        public void CreateMessage(int profileId, string text, int chatId)
        {
            messageController.CreateMessage(profileId, text, chatId);
            foreach(IMessageCallBack callBack in clientList)
            {
                callBack.GetMessage(text);
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
