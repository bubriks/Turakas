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
        private DbActivity dbActivity = null;
        private IProfileController profileController = null;
        private IGroupController groupController = null;
        private static List<Chat> chats = new List<Chat>();

        public ChatController()
        {
            dbChat = new DbChat();
            dbActivity = new DbActivity();
            profileController = new ProfileController();
            groupController = new GroupController();
        }
        
        public bool SaveChat(int profileId, Chat chat)
        {
            try
            {
                if (chat.MaxNrOfUsers > 1 && !chat.Name.Equals(""))
                {
                    if (chat.Id == 0)//new chat if id = 0
                    {
                        chat.Id = dbActivity.CreateActivity(chat.OwnerID);
                        if (dbChat.CreateChat(chat) == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else//update existing chat
                    {
                        if (profileId == chat.OwnerID)//if the owner of the chat
                        {
                            if (dbChat.UpdateChat(chat) == 0)//no changes were made
                            {
                                return false;
                            }

                            Chat foundChat = FindChat(chat.Id);//finds chat
                            if (foundChat != null)//if chat was found
                            {
                                lock (foundChat)//locks the chat so only one person ca edit it
                                {
                                    foundChat.MaxNrOfUsers = chat.MaxNrOfUsers;
                                    foundChat.Name = chat.Name;
                                    foundChat.Type = chat.Type;
                                }
                            }
                            return true;//returns chat if everything went correctly
                        }
                        else//not owner of chat
                        {
                            return false;
                        }
                    }
                }
                else//limit of users too small or no name
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool DeleteChat(int profileId, int id)
        {
            try
            {
                if (dbActivity.DeleteActivity(profileId, id) == 1)//if chat wasnt deleted
                {
                    Chat foundChat = FindChat(id);//checks if chat is active
                    if (foundChat != null)
                    {
                        lock (chats)//locks chats 
                        {
                            chats.Remove(foundChat);//removes chat from active chats
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Chat> GetChatsByName(String name, int profileId)
        {
            try
            {
                List<Chat> chatlist = new List<Chat>();//creates list of chats that user will recieve
                foreach (Chat chat in dbChat.GetChatsByName(name, profileId))
                {
                    Chat chatitem = FindChat(chat.Id);//trys finding the active chat 
                    if (chatitem != null)//if active chat was found is is added to list
                    {
                        chatlist.Add(chatitem);
                    }
                    else//chat wasnt found chat from db is added
                    {
                        chatlist.Add(chat);
                    }
                }
                return chatlist;//returns list of chats if everything went correctly
            }
            catch (Exception)
            {
                return new List<Chat>();//returns empty list of chats if exception is thrown
            }
        }
        
        public List<Profile> JoinChatWithGroup(int groupId, int chatId)
        {
            List<Profile> profiles = groupController.GetOnlineMembers(groupId);//gets all online members of the group
            Chat chat = FindChat(chatId);//finds active chat
            try
            {
                if (chat != null)//chat is active right now
                {
                    lock (chat)//locks the chat object so only one process can access it
                    {
                        List<Tuple<Profile, object>> membersToJoin = new List<Tuple<Profile, object>>();//list where members who have to join will be stored
                        foreach (Profile member in profiles)
                        {
                            Tuple<Profile, object> user = chat.Users.Find(
                            delegate (Tuple<Profile, object> tuple)
                            {
                                return tuple.Item1.ProfileID == member.ProfileID;
                            }
                            );

                            if (user == null)//if user isnt in chat already
                            {
                                membersToJoin.Add(new Tuple<Profile, object>(member, null));//adds the member to list (who will join chat)
                            }
                            else
                            {
                                profiles.Remove(user.Item1);//removes user from profiles if hi is already in chat so we dont have to call him back
                            }
                        }

                        if ((chat.MaxNrOfUsers - chat.Users.Count) >= membersToJoin.Count)//ok nr of people in chat
                        {
                            chat.Users.AddRange(membersToJoin);//adds this list to already existing list
                            return profiles;//persons added to chat
                        }
                        else
                        {
                            return new List<Profile>();//too few places
                        }
                    }
                }
                else
                {
                    lock (chats)
                    {
                        chat = dbChat.GetChat(chatId);//Gets chat from database
                        if (chat.MaxNrOfUsers >= profiles.Count)
                        {
                            List<Tuple<Profile, object>> membersToJoin = new List<Tuple<Profile, object>>();
                            foreach (Profile user in profiles)
                            {
                                membersToJoin.Add(new Tuple<Profile, object>(user, null));//member added to list of members to join
                            }
                            chat.Users = membersToJoin;//adds user to chat
                            chats.Add(chat);//adds chat to chat list
                            return profiles;//Returns joined users
                        }
                        else
                        {
                            return new List<Profile>();//too few spots in chatbox (no one has joined)
                        }
                    }
                }
            }
            catch (Exception)
            {
                return new List<Profile>();//something went wrong (no one should be called back)
            }
        }

        public bool JoinChat(int chatId, int profileId, object callback)
        {
            try
            {
                Chat chat = FindChat(chatId);//finds active chat
                if (chat != null)//if chat is active
                {
                    lock (chat)//locks the chat object so it cant be changed at the same time
                    {
                        Tuple<Profile, object> user = chat.Users.Find(
                        delegate (Tuple<Profile, object> tuple)
                        {
                            return tuple.Item1.ProfileID == profileId;
                        }
                        );

                        if (user == null)//if user wanst found
                        {
                            if (chat.MaxNrOfUsers > chat.Users.Count)//if chat can have that many users
                            {
                                chat.Users.Add(new Tuple<Profile, object>(profileController.GetUser(profileId), callback));//adds user to list
                                return true;//joined
                            }
                            else
                            { 
                                return false;//too many people in chat
                            }
                        }
                        else//user is in the chat
                        {
                            if (user.Item2 == null)//if user doesnt have callback assigned
                            {
                                chat.Users.Remove(user);
                                chat.Users.Add(new Tuple<Profile, object>(user.Item1, callback));
                                return true;//joined
                            }
                            else
                            {
                                return false;//trying to open 2nd window
                            }
                        }
                    }
                }
                else//chat isnt active right now
                {
                    lock (chats)
                    {
                        chat = dbChat.GetChat(chatId);//Gets chat from database
                        Profile user = profileController.GetUser(profileId);
                        if(user == null)
                        {
                            return false;
                        }
                        List<Tuple<Profile, object>> membersToJoin = new List<Tuple<Profile, object>>();//adds user to chat users
                        membersToJoin.Add(new Tuple<Profile, object>(user, callback));
                        chat.Users = membersToJoin;//adds users to chat
                        chats.Add(chat);//adds chat to chat list
                        return true;//joined
                    }
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
                lock (chat)//locks chat so only one proces can make changes to it at a time
                {
                    Tuple<Profile, object> user = chat.Users.Find(
                    delegate (Tuple<Profile, object> tuple)
                    {
                        return tuple.Item1.ProfileID == profileId;
                    }
                    );

                    if (user == null)//if user wasnt found
                    {
                        return false;
                    }
                    else//user found
                    {
                        if (chat.Users.Count <= 1)//if chat has only one user in it
                        {
                            lock (chats)//locks chats so there can be no conflict
                            {
                                chats.Remove(chat);//removes chat from chat list
                                return true;
                            }
                        }
                        else
                        {
                            chat.Users.Remove(user);//removes user from chat
                            return true;
                        }
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
            Chat chat = chats.Find(//finds chat with this id
            delegate (Chat c)
            {
                return c.Id == chatId;
            }
            );
            return chat;
        }
    }
}
