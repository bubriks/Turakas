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

        public Chat CreateChat(Chat chat, int profileId)
        {
            return chatController.CreateChat(chat, profileId);
        }

        public List<Chat> GetChatsByName(String name)
        {
            return chatController.GetChatsByName(name);
        }

        public bool UpdateChat(Chat chat)
        {
            return chatController.UpdateChat(chat);
        }

        public bool DeleteChat(int id)
        {
            return chatController.DeleteChat(id);
        }
    }
}
