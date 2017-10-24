using DataTier;
using DataAccessTier;
using System;
using System.Collections;

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

        public String GetPersonsInChat(int chatId)
        {
            try
            {
                return dbChat.GetPersonsInChat(chatId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddPersonToChat(int chatId, int personId)
        {
            try
            {
                dbChat.AddPersonToChat(chatId, personId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemovePersonFromChat(int chatId, int personId)
        {
            try
            {
                dbChat.RemovePersonFromChat(chatId, personId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
