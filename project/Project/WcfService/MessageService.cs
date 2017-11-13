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
        private IMessageController messageController = new MessageController();
        private IChatController chatController = new ChatController();

        public void JoinChat(int chatId, int profileId)
        {
            object callbackObj = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();
            IMessageCallBack callback = (IMessageCallBack)callbackObj;
            if (chatController.JoinChat(chatId, profileId, callbackObj))
            {
                callback.GetChat(chatController.FindChat(chatId));
                callback.GetMessages(messageController.GetMessages(chatId));

                List<Profile> profiles = new List<Profile>();
                foreach (User user in chatController.FindChat(chatId).Users)
                {
                    profiles.Add(user.Profile);
                }

                foreach (User user in chatController.FindChat(chatId).Users)
                {
                    callback = (IMessageCallBack)user.CallBack;
                    callback.GetOnlineProfiles(profiles);
                }
            }
        }

        public void LeaveChat(int chatId, int profileId)
        {
            if(chatController.LeaveChat(chatId, profileId))
            {
                List<Profile> profiles = new List<Profile>();
                foreach(User user in chatController.FindChat(chatId).Users)
                {
                    profiles.Add(user.Profile);
                }

                foreach (User user in chatController.FindChat(chatId).Users)
                {
                    IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                    callback.GetOnlineProfiles(profiles);
                }
            }
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
