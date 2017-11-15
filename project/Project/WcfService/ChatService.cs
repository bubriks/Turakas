using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using BusinessTier;

namespace WcfService
{
    public class ChatService: IChatService
    {
        IChatController chatController = new ChatController();

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

        public List<Chat> GetChatsByName(String name)
        {
            return chatController.GetChatsByName(name);
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
    }
}
