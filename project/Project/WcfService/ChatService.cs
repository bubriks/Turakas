using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using BusinessTier;
using System.ServiceModel;

namespace WcfService
{
    public class ChatService: IChatService
    {
        IChatController chatController = new ChatController();
        IProfileController profileController = new ProfileController();

        public void Online(int profileId)
        {
            object callbackObj = OperationContext.Current.GetCallbackChannel<IChatCallBack>();
            profileController.Online(profileId, callbackObj);
        }

        public void Offline(int profileId)
        {
            profileController.Offline(profileId);
        }

        public bool invite(int chatId, String name)
        {
            Profile user = profileController.GetUser(name);
            if (user != null)
            {
                IChatCallBack chatCallback = (IChatCallBack)user.CallBack;
                chatCallback.Notification(chatController.FindChat(chatId));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveChat(Chat chat)
        {
            if(chatController.SaveChat(chat) != null && chat.Id != 0)
            {
                chat = chatController.FindChat(chat.Id);
                if (chat != null)
                {
                    foreach (Profile user in chat.Users)
                    {
                        IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                        callback.GetChat(chat);
                    }
                }
            }
        }

        public void DeleteChat(int id)
        {
            Chat chat = chatController.FindChat(id);
            if (chatController.DeleteChat(id))
            {
                if (chat != null)
                {
                    foreach (Profile user in chat.Users)
                    {
                        IMessageCallBack callback = (IMessageCallBack)user.CallBack;
                        callback.Show(false);
                    }
                }
            }
        }

        public List<Chat> GetChatsByName(String name, int profileId)
        {
            return chatController.GetChatsByName(name, profileId);
        }
    }
}
