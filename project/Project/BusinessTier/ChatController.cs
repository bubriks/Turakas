using DataTier;
using DataAccessTier;
using System;
using System.Collections;
using System.Transactions;

namespace BusinessTier
{
    public class ChatController: IChatController
    {
        private static DbChat dbChat = null;

        public ChatController()
        {
            dbChat = new DbChat();
        }

        public Chat CreateChat(Chat chat, int personId)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    chat = dbChat.CreateChat(chat);
                    dbChat.AddPersonToChat(chat.Id, personId);
                    ts.Complete();
                    return chat;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public Chat GetChat(int id)
        {
            try
            {
                return dbChat.GetChat(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateChat(Chat chat)
        {
            try
            {
                dbChat.UpdateChat(chat);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteChat(int id)
        {
            try
            {
                dbChat.DeleteChat(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
