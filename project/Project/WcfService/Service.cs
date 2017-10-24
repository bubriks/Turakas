using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;
using System.Collections;

namespace WcfService
{
    public class Service : IService
    {
        static IChatController chatController = new ChatController();

        public Chat CreateChat(Chat chat)
        {
            return chatController.CreateChat(chat);
        }

        public Chat GetChat(int id)
        {
            return chatController.GetChat(id);
        }

        public bool UpdateChat(Chat chat)
        {
            return chatController.UpdateChat(chat);
        }

        public bool DeleteChat(int id)
        {
            return chatController.DeleteChat(id);
        }

        public string GetPersonsInChat(int chatId)
        {
            return chatController.GetPersonsInChat(chatId);
        }

        public bool AddPersonToChat(int chatId, int personId)
        {
            return chatController.AddPersonToChat(chatId, personId);
        }

        public bool RemovePersonFromChat(int chatId, int personId)
        {
            return chatController.RemovePersonFromChat(chatId, personId);
        }
    }
}
