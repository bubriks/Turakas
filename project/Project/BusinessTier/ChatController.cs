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
        private static List<Chat> chats = null;

        public ChatController()
        {
            dbChat = new DbChat();
            profileController = new ProfileController();
            con = DbConnection.GetInstance();
            chats = new List<Chat>();
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
                        if (foundChat != null)//if in use update chat in use
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

        public bool JoinChat(int chatId, int profileId, object callback)
        {
            try
            {
                Chat chat = FindChat(chatId);
                if (chat != null)//chat exists
                {
                    if (chat.MaxNrOfUsers > chat.Users.Count)//less people in chat than max nr
                    {
                        Profile user = chat.Users.Find(
                        delegate (Profile u)
                        {
                            return u.ProfileID == profileId;
                        }
                        );

                        if (user != null)//user is already in chat
                        {
                            return false;
                        }

                        user = profileController.ReadProfile(profileId.ToString(), 1);//gets the user from database
                        user.CallBack = callback;//adds callback object to it
                        List<Profile> list = chat.Users;//gets chats user list
                        list.Add(user);//adds user to list
                        chat.Users = list;//replaces chats user list with the new one
                        //joined
                        return true;
                    }
                    //couldnt join becouse its full
                    return false;
                }
                else
                {
                    chat = dbChat.GetChat(chatId);//Gets chat from database
                    Profile user = profileController.ReadProfile(profileId.ToString(), 1);//gets user from database
                    user.CallBack = callback;//adds callback object to it
                    List<Profile> list = new List<Profile>//creates new user list
                    {
                        user//adds user to this list
                    };
                    chat.Users = list;//replaces chats user list with the new one
                    chats.Add(chat);//adds chat to chat list
                    //joined
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool LeaveChat(int chatId, int profileId)
        {
            try
            {
                Chat chat = FindChat(chatId);//looks for existing chat
                foreach (Profile user in chat.Users)
                {
                    if (user.ProfileID == profileId)
                    {
                        if (chat.Users.Count <= 1)
                        {
                            //removes chat if it would be empty
                            chats.Remove(chat);
                            return true;
                        }
                        else
                        {
                            //removes user from chat
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
