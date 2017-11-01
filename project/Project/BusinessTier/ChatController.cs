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
        private SqlTransaction transaction = null;

        public ChatController()
        {
            dbChat = new DbChat();
        }
        
        public Chat CreateChat(Chat chat, int profileId)
        {
            //Creates new starnsaction
            transaction = DbConnection.GetInstance().GetConnection().BeginTransaction();
            try
            {
                //passes the transaction further to DataAccessTier
                chat = dbChat.CreateChat(chat, transaction);
                dbChat.AddPersonToChat(chat.Id, profileId, transaction);
                //if everything goes as planed than commited
                transaction.Commit();
                //returns Object if everything went correctly
                return chat;
            }
            catch (Exception)
            {
                //If exception is thrown the transaction is rolled back and null is returned
                transaction.Rollback();
                return null;
            }
        }

        public List<Chat> GetChatsByName(String name)
        {
            try
            {
                //returns list of objects if everything went correctly
                return dbChat.GetChatsByName(name);
            }
            catch (Exception)
            {
                //returns empty list if exception is thrown
                return new List<Chat>();
            }
        }

        public bool UpdateChat(Chat chat)
        {
            try
            {
                if (dbChat.UpdateChat(chat) == 0)
                {
                    //returns false if no changes were made
                    return false;
                }
                //returns true if everything went correctly
                return true;
            }
            catch (Exception)
            {
                //returns false if exception is thrown
                return false;
            }
        }

        public bool DeleteChat(int id)
        {
            try
            {
                if (dbChat.DeleteChat(id, null) == 0)
                {
                    //returns false if no changes were made
                    return false;
                }
                //returns true if everything went correctly
                return true;
            }
            catch (Exception)
            {
                //returns false if exception is thrown
                return false;
            }
        }

        public List<Chat> GetPersonsChats(int profileId)
        {
            try
            {
                //returns list of objects if everything went correctly
                return dbChat.GetPersonsChats(profileId);
            }
            catch (Exception)
            {
                //returns empty list if exception is thrown
                return new List<Chat>();
            }
        }

        public List<Profile> GetPersonsInChat(int chatId)
        {
            try
            {
                //returns list of objects if everything went correctly
                return dbChat.GetPersonsInChat(chatId, null);
            }
            catch (Exception)
            {
                //returns empty list if exception is thrown
                return new List<Profile>();
            }
        }

        public bool AddPersonToChat(int chatId, int profileId)
        {
            try
            {
                //returns true if everything went correctly
                return dbChat.AddPersonToChat(chatId, profileId, null);
            }
            catch (Exception)
            {
                //returns false if exception is thrown
                return false;
            }
        }

        public bool RemovePersonFromChat(int chatId, int profileId)
        {
            //Creates new starnsaction
            transaction = DbConnection.GetInstance().GetConnection().BeginTransaction();
            try
            {
                if (dbChat.RemovePersonFromChat(chatId, profileId, transaction) == 0)
                {
                    transaction.Rollback();
                    //returns false if no changes were made
                    return false;
                }
                if (dbChat.GetPersonsInChat(chatId, transaction).Count == 0)
                {
                    if (dbChat.DeleteChat(chatId, transaction) == 0)
                    {
                        transaction.Rollback();
                        //returns false if chat wasnt deleted
                        return false;
                    }
                }
                transaction.Commit();
                //returns true if everything went correctly
                return true;
            }
            catch (Exception)
            {
                //If exception is thrown the transaction is rolled back and null is returned
                transaction.Rollback();
                return false;
            }
        }
    }
}
