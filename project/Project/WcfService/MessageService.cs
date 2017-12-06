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
                List<Tuple<object, int>> callbacks = new List<Tuple<object, int>>();
                List<Profile> profiles = new List<Profile>();
                foreach (var tuple in chat.Users)
                {
                    profiles.Add(tuple.Item1);
                    if(tuple.Item2 != null)
                    {
                        callbacks.Add(new Tuple<object, int>(tuple.Item2, tuple.Item1.ProfileID));
                    }
                }
                callback.GetChat(chat);
                callback.GetMessages(messageController.GetMessages(chatId));
                callback.GetOnlineProfiles(profiles);
                callback.Show(true);
                
                foreach (Tuple<object, int> messageCallBack in callbacks)
                {
                    try
                    {
                        callback = (IMessageCallBack)messageCallBack.Item1;
                        callback.GetOnlineProfiles(profiles);
                    }
                    catch (Exception)
                    {
                        chatController.LeaveChat(chatId, messageCallBack.Item2);
                    }
                }
            }
            else
            {
                callback.Show(false);
            }
        }

        public void LeaveChat(int chatId, int profileId)
        {
            if (chatController.LeaveChat(chatId, profileId))
            {
                Chat chat = chatController.FindChat(chatId);
                if (chat != null)
                {
                    List<Tuple<object, int>> callbacks = new List<Tuple<object, int>>();
                    List<Profile> profiles = new List<Profile>();
                    foreach (var tuple in chat.Users)
                    {
                        profiles.Add(tuple.Item1);
                        if(tuple.Item2 != null)
                        {
                            callbacks.Add(new Tuple<object, int>(tuple.Item2, tuple.Item1.ProfileID));
                        }
                    }

                    foreach (Tuple<object, int> messageCallBack in callbacks)
                    {
                        try
                        {
                            IMessageCallBack callback = (IMessageCallBack)messageCallBack.Item1;
                            callback.GetOnlineProfiles(profiles);
                        }
                        catch (Exception)
                        {
                            chatController.LeaveChat(chatId, messageCallBack.Item2);
                        }
                    }
                }
            }
        }

        public void InviteToChat(int chatId, string name)
        {
            IMessageCallBack callback = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();
            callback.Invite(new ChatService().Invite(chatId, name));
        }

        public void Writing(int chatId)
        {
            foreach (var tuple in chatController.FindChat(chatId).Users)
            {
                try
                {
                    IMessageCallBack callback = (IMessageCallBack)tuple.Item2;
                    callback.WritingMessage();
                }
                catch (Exception)
                {
                    chatController.LeaveChat(chatId, tuple.Item1.ProfileID);
                }
            }
        }
        
        public void CreateMessage(int profileId, string text, int chatId)
        {
            Message message = messageController.CreateMessage(profileId, text, chatId);
            if (message != null)
            {
                foreach (var tuple in chatController.FindChat(chatId).Users)
                {
                    try
                    {
                        IMessageCallBack callback = (IMessageCallBack)tuple.Item2;
                        callback.AddMessage(message);
                    }
                    catch (Exception)
                    {
                        chatController.LeaveChat(chatId, tuple.Item1.ProfileID);
                    }
                }
            }
        }

        public void DeleteMessage(int profileId, int id, int chatId)
        {
            if (messageController.DeleteMessage(profileId, id))
            {
                foreach (var tuple in chatController.FindChat(chatId).Users)
                {
                    try
                    {
                        IMessageCallBack callback = (IMessageCallBack)tuple.Item2;
                        callback.RemoveMessage(id);
                    }
                    catch (Exception)
                    {
                        chatController.LeaveChat(chatId, tuple.Item1.ProfileID);
                    }
                }
            }
        }
    }
}
