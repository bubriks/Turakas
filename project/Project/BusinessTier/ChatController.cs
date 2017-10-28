using DataTier;
using DataAccessTier;
using System;
using System.Transactions;
using System.Collections.Generic;

namespace BusinessTier
{
    public class ChatController: IChatController
    {
        private DbChat dbChat = null;

        public ChatController()
        {
            dbChat = new DbChat();
        }

        public Chat CreateChat(Chat chat, int profileId)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    chat = dbChat.CreateChat(chat);
                    dbChat.AddPersonToChat(chat.Id, profileId);
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

        public List<Chat> GetChatsByName(String name)
        {
            try
            {
                return dbChat.GetChatsByName(name);
            }
            catch (Exception)
            {
                return new List<Chat>();
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

        public List<Profile> GetPersonsInChat(int chatId)
        {
            try
            {
                return dbChat.GetPersonsInChat(chatId);
            }
            catch (Exception)
            {
                return new List<Profile>();
            }
        }

        public bool AddPersonToChat(int chatId, int profileId)
        {
            try
            {
                dbChat.AddPersonToChat(chatId, profileId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemovePersonFromChat(int chatId, int profileId)
        {
            try
            {
                dbChat.RemovePersonFromChat(chatId, profileId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
