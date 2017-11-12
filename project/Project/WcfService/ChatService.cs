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

        public Chat SaveChat(Chat chat)
        {
            return chatController.SaveChat(chat);
        }

        public List<Chat> GetChatsByName(String name)
        {
            return chatController.GetChatsByName(name);
        }

        public bool DeleteChat(int id)
        {
            return chatController.DeleteChat(id);
        }
    }
}
