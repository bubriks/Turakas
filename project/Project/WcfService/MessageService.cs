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
    public class MessageService : IMessageService
    {
        //will need chaging
        private IMessageController messageController = new MessageController();
        private IChatController chatController = new ChatController();

        public bool JoinChat(int chatId, int profileId)
        {
            object callback = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();
            return chatController.JoinChat(chatId, profileId, callback);
        }

        public bool LeaveChat(int chatId, int profileId)
        {
            return chatController.LeaveChat(chatId, profileId);
        }

        public List<Profile> GetOnlineProfiles(int chatId)
        {
            List<Profile> profiles = new List<Profile>();
            foreach(User user in chatController.FindChat(chatId).Users)
            {
                profiles.Add(user.Profile);
            }
            return profiles;
        }

        public Chat GetChat(int chatId)
        {
            return chatController.FindChat(chatId);
        }

        public void CreateMessage(int profileId, string text, int chatId)
        {
            Message message = messageController.CreateMessage(profileId, text, chatId);
            if (message != null)
            {
                foreach (User user in chatController.FindChat(chatId).Users)
                {
                    IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                    callback.AddMessage(message);
                }
            }
        }

        public List<Message> GetMessages(int chatId)
        {
            return messageController.GetMessages(chatId);
        }

        public void DeleteMessage(int id, int chatId)
        {
            if (messageController.DeleteMessage(id))
            {
                foreach (User user in chatController.FindChat(chatId).Users)
                {
                    IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                    callback.RemoveMessage(id);
                }
            }
        }
    }
}
