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
                List<object> callbacks = new List<object>();
                List<Profile> profiles = new List<Profile>();
                foreach (var tuple in chat.Users)
                {
                    profiles.Add(tuple.Item1);
                    if(tuple.Item2 != null)
                    {
                        callbacks.Add(tuple.Item2);
                    }
                }
                callback.GetChat(chat);
                callback.GetMessages(messageController.GetMessages(chatId));
                callback.GetOnlineProfiles(profiles);
                callback.Show(true);
                
                foreach (object messageCallBack in callbacks)
                {
                    callback = (IMessageCallBack)messageCallBack;
                    callback.GetOnlineProfiles(profiles);
                }
            }
            else
            {
                callback.Show(false);
            }
        }

        public void LeaveChat(int chatId, int profileId)
        {
            Chat chat = chatController.FindChat(chatId);
            if (chatController.LeaveChat(chatId, profileId))
            {
                if(chat != null)
                {
                    List<object> callbacks = new List<object>();
                    List<Profile> profiles = new List<Profile>();
                    foreach (var tuple in chat.Users)
                    {
                        profiles.Add(tuple.Item1);
                        callbacks.Add(tuple.Item2);
                    }

                    foreach (object messageCallBack in callbacks)
                    {
                        IMessageCallBack callback = (IMessageCallBack)messageCallBack;
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
            foreach (var tuple in chatController.FindChat(chatId).Users)
            {
                IMessageCallBack callback = (IMessageCallBack)tuple.Item2;
                callback.WritingMessage();
            }
        }
        
        public void CreateMessage(int profileId, string text, int chatId)
        {
            Message message = messageController.CreateMessage(profileId, text, chatId);
            if (message != null)
            {
                foreach (var tuple in chatController.FindChat(chatId).Users)
                {
                    IMessageCallBack callback = (IMessageCallBack)tuple.Item2;
                    callback.AddMessage(message);
                }
            }
        }

        public void DeleteMessage(int profileId, int id, int chatId)
        {
            if (messageController.DeleteMessage(profileId, id))
            {
                foreach (var tuple in chatController.FindChat(chatId).Users)
                {
                    IMessageCallBack callback = (IMessageCallBack)tuple.Item2;
                    callback.RemoveMessage(id);
                }
            }
        }
    }
}
