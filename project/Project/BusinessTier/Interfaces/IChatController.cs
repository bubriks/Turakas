using DataTier;
using System;
using System.Collections.Generic;

namespace BusinessTier
{
    public interface IChatController
    {
        /// <summary>
        /// Creates or updates chat and automaticly adds the creator to it
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        Chat SaveChat(int profileId, Chat chat);
        /// <summary>
        /// Deletes chat which holds this id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteChat(int profileId, int id);
        /// <summary>
        /// Gets chats which name includes this text
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Chat> GetChatsByName(String name, int profileId);
        /// <summary>
        /// returns all online group members that are added to chat
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        List<Profile> JoinChatWithGroup(int groupId, int chatId);
        /// <summary>
        /// Person joins chat
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="profileId"></param>
        /// <param name="callback"></param>
        bool JoinChat(int chatId, int profileId, object callback);
        /// <summary>
        /// Person leaves chat
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="profileId"></param>
        bool LeaveChat(int chatId, int profileId);
        /// <summary>
        /// Finds existing chat for chatroom
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        Chat FindChat(int chatId);
    }
}
