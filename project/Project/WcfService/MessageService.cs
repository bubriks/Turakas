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
                Chat chat = chatController.FindChat(chatId);
                callback.GetChat(chat);
                callback.GetMessages(messageController.GetMessages(chatId));
                callback.GetOnlineProfiles(chat.Users);

                List<Profile> profiles = chat.Users;
                foreach (Profile user in profiles)
                {
                    callback = (IMessageCallBack)user.CallBack;
                    callback.GetOnlineProfiles(profiles);
                }
                callback.Show(true);
            }
            else
            {
                callback.Show(false);
            }
        }

        public void LeaveChat(int chatId, int profileId)
        {
            if(chatController.LeaveChat(chatId, profileId))
            {
                Chat chat = chatController.FindChat(chatId);
                if(chat != null)
                {
                    List<Profile> profiles = chat.Users;
                    foreach (Profile user in profiles)
                    {
                        IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                        callback.GetOnlineProfiles(profiles);
                    }
                }
            }
        }

        public void InviteToChat(int chatId, String name)
        {
            IMessageCallBack callback = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();
            callback.Invite(new ChatService().invite(chatId, name));
        }

        public void Writing(int chatId)
        {
            List<Profile> profiles = chatController.FindChat(chatId).Users;
            foreach (Profile user in profiles)
            {
                IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                callback.WritingMessage();
            }
        }
        
        public void CreateMessage(int profileId, string text, int chatId)
        {
            Message message = messageController.CreateMessage(profileId, text, chatId);
            if (message != null)
            {
                foreach (Profile user in chatController.FindChat(chatId).Users)
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
                foreach (Profile user in chatController.FindChat(chatId).Users)
                {
                    IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                    callback.RemoveMessage(id);
                }
            }
        }
    }
}
