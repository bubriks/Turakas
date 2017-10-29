using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;

namespace WcfService
{
    public class Service : IService
    {
        IChatController chatController = new ChatController();
        IMessageController messageController = new MessageController();

        #region chat
        public Chat CreateChat(Chat chat, int profileId)
        {
            return chatController.CreateChat(chat, profileId);
        }

        public Chat GetChat(int id)
        {
            return chatController.GetChat(id);
        }

        public List<Chat> GetChatsByName(String name)
        {
            return chatController.GetChatsByName(name);
        }

        public bool UpdateChat(Chat chat)
        {
            return chatController.UpdateChat(chat);
        }

        public bool DeleteChat(int id)
        {
            return chatController.DeleteChat(id);
        }

        public List<Profile> GetPersonsInChat(int chatId)
        {
            return chatController.GetPersonsInChat(chatId);
        }

        public bool AddPersonToChat(int chatId, int profileId)
        {
            return chatController.AddPersonToChat(chatId, profileId);
        }

        public bool RemovePersonFromChat(int chatId, int profileId)
        {
            return chatController.RemovePersonFromChat(chatId, profileId);
        }
        #endregion

        #region message
        public bool CreateMessage(int profileId, string text, int chatId)
        {
            return messageController.CreateMessage(profileId, text, chatId);
        }

        public Message GetMessage(int id)
        {
            return messageController.GetMessage(id);
        }

        public List<Message> GetMessages(int chatId)
        {
            return messageController.GetMessages(chatId);
        }

        public bool DeleteMessage(int id)
        {
            return messageController.DeleteMessage(id);
        }
        #endregion
    }
}
