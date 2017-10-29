using DataTier;
using DataAccessTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            SqlTransaction transaction = DbConnection.GetInstance().GetConnection().BeginTransaction();
            try
            {
                chat = dbChat.CreateChat(chat, transaction);
                dbChat.AddPersonToChat(chat.Id, profileId, transaction);
                transaction.Commit();
                return chat;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
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
                if (dbChat.UpdateChat(chat) == 0)
                {
                    return false;
                }
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
                if (dbChat.DeleteChat(id) == 0)
                {
                    return false;
                }
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
                dbChat.AddPersonToChat(chatId, profileId, null);
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
                if (dbChat.RemovePersonFromChat(chatId, profileId) == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
