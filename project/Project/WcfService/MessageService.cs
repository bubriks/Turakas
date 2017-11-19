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

                List<Profile> profiles = chatController.FindChat(chatId).Users;
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
                List<Profile> profiles = chatController.FindChat(chatId).Users;
                foreach (Profile user in profiles)
                {
                    IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                    callback.GetOnlineProfiles(profiles);
                }
            }
        }

        public void InviteToChat(int chatId, String name)
        {
            IMessageCallBack callback = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();
            IProfileController profileController = new ProfileController();
            Profile user = profileController.OnlineUsers().Find(
            delegate (Profile u)
            {
                return u.Nickname.Equals(name);
            }
            );
            if(user != null)
            {
                IChatCallBack chatCallback = (IChatCallBack)user.CallBack;
                chatCallback.Notification(chatController.FindChat(chatId));
                callback.Invite(true);
            }
            else
            {
                callback.Invite(false);
            }
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
