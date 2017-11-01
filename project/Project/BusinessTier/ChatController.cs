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
        private DbConnection con = null;

        public ChatController()
        {
            dbChat = new DbChat();
            con = DbConnection.GetInstance();
        }
        
        public Chat CreateChat(Chat chat, int profileId)
        {
            //Creates new transaction
            con.BeginTransaction();
            try
            {
                //passes the transaction further to DataAccessTier
                chat = dbChat.CreateChat(chat);
                dbChat.AddPersonToChat(chat.Id, profileId);
                //if everything goes as planed than commited
                con.Commit();
                //returns Object if everything went correctly
                return chat;
            }
            catch (Exception)
            {
                //If exception is thrown the transaction is rolled back and null is returned
                con.Rollback();
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
                if (dbChat.DeleteChat(id) == 0)
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
                return dbChat.GetPersonsInChat(chatId);
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
                return dbChat.AddPersonToChat(chatId, profileId);
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
            con.BeginTransaction();
            try
            {
                if (dbChat.RemovePersonFromChat(chatId, profileId) == 0)
                {
                    con.Rollback();
                    //returns false if no changes were made
                    return false;
                }
                if (dbChat.GetPersonsInChat(chatId).Count == 0)
                {
                    if (dbChat.DeleteChat(chatId) == 0)
                    {
                        con.Rollback();
                        //returns false if chat wasnt deleted
                        return false;
                    }
                }
                con.Commit();
                //returns true if everything went correctly
                return true;
            }
            catch (Exception)
            {
                //If exception is thrown the transaction is rolled back and null is returned
                con.Rollback();
                return false;
            }
        }
    }
}
