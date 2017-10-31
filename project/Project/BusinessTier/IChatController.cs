using DataTier;
using System;
using System.Collections.Generic;

namespace BusinessTier
{
    public interface IChatController
    {
        /// <summary>
        /// Creates chat and automaticly adds the creator to it
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        Chat CreateChat(Chat chat, int profileId);
        /// <summary>
        /// Gets chat with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Chat GetChat(int id);
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
        /// Returns all users chats (which he is part of)
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        List<Chat> GetPersonsChats(int profileId);
        /// <summary>
        /// Gets profiles in selected chat
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        List<Profile> GetPersonsInChat(int chatId);
        /// <summary>
        /// Adds profile to specific chat
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        bool AddPersonToChat(int chatId, int profileId);
        /// <summary>
        /// Removes profile from specific chat
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        bool RemovePersonFromChat(int chatId, int profileId);
    }
}
