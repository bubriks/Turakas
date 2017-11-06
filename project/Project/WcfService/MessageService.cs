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

        public bool CreateMessage(int profileId, string text, int chatId)
        {
            return messageController.CreateMessage(profileId, text, chatId);
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
