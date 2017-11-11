using DataTier;
using System;
using System.Collections.Generic;

namespace BusinessTier
{
    public interface IChatController
    {
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
        /// Creates chat and automaticly adds the creator to it
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        Chat CreateChat(Chat chat, int profileId);
        /// <summary>
        /// Gets chats which name includes this text
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Chat> GetChatsByName(String name);
        /// <summary>
        /// Updates existing chat with the new details
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        bool UpdateChat(Chat chat);
        /// <summary>
        /// Deletes chat which holds this id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteChat(int id);
        /// <summary>
        /// Finds existing chat for chatroom
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        Chat FindChat(int chatId);
    }
}
