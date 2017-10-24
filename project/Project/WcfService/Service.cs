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
    }
}
