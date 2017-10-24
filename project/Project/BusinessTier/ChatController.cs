using DataTier;
using DataAccessTier;
using System;

namespace BusinessTier
{
    public class ChatController: IChatController
    {
        private static DbChat dbChat = null;

        public ChatController()
        {
            dbChat = new DbChat();
        }

        public Chat CreateChat(Chat chat)
        {
            return dbChat.CreateChat(chat);
        }

        public Chat GetChat(int id)
        {
            return dbChat.GetChat(id);
        }

        public bool UpdateChat(Chat chat)
        {
            return dbChat.UpdateChat(chat);
        }

        public bool DeleteChat(int id)
        {
            return dbChat.DeleteChat(id);
        }
    }
}
