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
        private IProfileController profileController = new ProfileController();
        private DbConnection con = null;
        private static List<Chat> chats = new List<Chat>();

        public ChatController()
        {
            dbChat = new DbChat();
            con = DbConnection.GetInstance();
        }

        public bool JoinChat(int chatId, int profileId, object callback)
        {
            try
            {
                Chat chat = FindChat(chatId);
                if (chat != null)
                {
                    if (chat.MaxNrOfUsers > chat.Users.Count)
                    {
                        User user = chat.Users.Find(
                        delegate (User u)
                        {
                            return u.Profile.ProfileID == profileId;
                        }
                        );

                        if(user != null)
                        {
                            //user is already in chat
                            return false;
                        }

                        user = new User
                        {
                            Profile = profileController.ReadProfile(profileId.ToString(), 1),
                            CallBack = callback
                        };
                        List<User> list = chat.Users;
                        list.Add(user);
                        chat.Users = list;
                        //joined
                        return true;
                    }
                    //couldnt join couse its full
                    return false;
                }
                else
                {
                    chat = GetChat(chatId);
                    User user = new User
                    {
                        Profile = profileController.ReadProfile(profileId.ToString(), 1),
                        CallBack = callback
                    };
                    List<User> list = new List<User>
                    {
                        user
                    };
                    chat.Users = list;
                    chats.Add(chat);
                    //joined
                    return true;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool LeaveChat(int chatId, int profileId)
        {
            try
            {
                Chat chat = FindChat(chatId);
                foreach (User user in chat.Users)
                {
                    if (user.Profile.ProfileID == profileId)
                    {
                        if (chat.Users.Count <= 1)
                        {
                            chats.Remove(chat);
                            return true;
                        }
                        else
                        {
                            chat.Users.Remove(user);
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Chat SaveChat(Chat chat)
        {
            try
            {
                if (chat.MaxNrOfUsers > 1)
                {
                    if (chat.Id == 0)
                    {
                        //returns Object if everything went correctly
                        return dbChat.CreateChat(chat);
                    }
                    else
                    {
                        if (dbChat.UpdateChat(chat) == null)
                        {
                            //returns null if no changes were made
                            return null;
                        }

                        Chat foundChat = FindChat(chat.Id);
                        if (foundChat != null)
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
                if (foundChat != null)
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

        private Chat GetChat(int id)
        {
            try
            {
                //returns object if everything went correctly
                return dbChat.GetChat(id);
            }
            catch (Exception)
            {
                //returns null if exception is thrown
                return null;
            }
        }
    }
}
