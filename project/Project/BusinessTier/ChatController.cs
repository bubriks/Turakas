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
        private IProfileController profileController = null;
        private DbConnection con = null;
        private static List<Chat> chats = new List<Chat>();

        public ChatController()
        {
            dbChat = new DbChat();
            profileController = new ProfileController();
            con = DbConnection.GetInstance();
        }

        public Chat SaveChat(Chat chat)
        {
            try
            {
                if (chat.MaxNrOfUsers > 1)
                {
                    if (chat.Id == 0)//new chat
                    {
                        //returns Object if everything went correctly
                        return dbChat.CreateChat(chat);
                    }
                    else
                    {
                        if (dbChat.UpdateChat(chat) == null)//no changes were made
                        {
                            return null;
                        }

                        Chat foundChat = FindChat(chat.Id);
                        lock (foundChat)
                        {
                            foundChat.MaxNrOfUsers = chat.MaxNrOfUsers;
                            foundChat.Name = chat.Name;
                            foundChat.Type = chat.Type;
                        }
                        //returns object if everything went correctly
                        return chat;
                    }
                }
                //max users too litle
                return null;
            }
            catch (Exception)
            {
                //If exception is thrown null is returned
                return null;
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
                
                Chat foundChat = FindChat(id);
                lock (chats)
                {
                    chats.Remove(foundChat);
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

        public List<Chat> GetChatsByName(String name)
        {
            try
            {
                List<Chat> chatlist = new List<Chat>();
                foreach (Chat chat in dbChat.GetChatsByName(name))
                {
                    Chat chatitem = FindChat(chat.Id);
                    if (chatitem != null)
                    {
                        chatlist.Add(chatitem);
                    }
                    else
                    {
                        chatlist.Add(chat);
                    }
                }
                //returns list of objects if everything went correctly
                return chatlist;
            }
            catch (Exception)
            {
                //returns empty list if exception is thrown
                return new List<Chat>();
            }
        }

        public bool JoinChat(int chatId, int profileId, object callback)
        {
            try
            {
                Chat chat = FindChat(chatId);
                lock (chat)
                {
                    if (chat.MaxNrOfUsers > chat.Users.Count)//ok nr of people in chat
                    {
                        Profile user = chat.Users.Find(
                        delegate (Profile u)
                        {
                            return u.ProfileID == profileId;
                        }
                        );

                        if (user == null)//person isnt in chat
                        {
                            user = profileController.ReadProfile(profileId.ToString(), 1);//gets the user from database
                            user.CallBack = callback;//adds callback object to it
                            chat.Users.Add(user);//adds user to list
                            return true;//joined
                        }

                        return false;//person in chat already
                    }
                    else//too many people in chat
                    {
                        return false;
                    }
                }
            }
            catch (Exception)//Chat isnt in chats list
            {
                try
                {
                    lock (chats)
                    {
                        Chat chat = dbChat.GetChat(chatId);//Gets chat from database
                        Profile user = profileController.ReadProfile(profileId.ToString(), 1);//gets user from database
                        user.CallBack = callback;//adds callback object to it
                        List<Profile> profiles = new List<Profile>();
                        profiles.Add(user);
                        chat.Users = profiles;//adds user to chat
                        chats.Add(chat);//adds chat to chat list
                        return true;//joined
                    }
                }
                catch (Exception)//catches exeption if something went wrong
                {
                    return false;
                }
            }
        }

        public bool LeaveChat(int chatId, int profileId)
        {
            try
            {
                Chat chat = FindChat(chatId);//looks for existing chat
                lock (chat)
                {
                    Profile user = chat.Users.Find(
                    delegate (Profile c)
                    {
                        return c.ProfileID == profileId;
                    }
                    );

                    if (chat.Users.Count <= 1)
                    {
                        lock (chats)
                        {
                            chats.Remove(chat);
                            return true;
                        }
                    }
                    else
                    {
                        //removes user from chat
                        chat.Users.Remove(user);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Chat FindChat(int chatId)
        {
            Chat chat = chats.Find(
            delegate (Chat c)
            {
                return c.Id == chatId;
            }
            );
            return chat;
        }
    }
}
