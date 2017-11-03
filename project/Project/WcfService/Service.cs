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
        IProfileController profileController = new ProfileController();
        ILoginController loginController = new LoginController();

        #region chat
        public Chat CreateChat(Chat chat, int profileId)
        {
            return chatController.CreateChat(chat, profileId);
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

        public List<Chat> GetPersonsChats(int profileId)
        {
            return chatController.GetPersonsChats(profileId);
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

        public List<Message> GetMessages(int chatId)
        {
            return messageController.GetMessages(chatId);
        }

        public bool DeleteMessage(int id)
        {
            return messageController.DeleteMessage(id);
        }
        #endregion

        #region login
        public bool CreateAccount(Login login)
        {
            return loginController.CreateAccount(login);
        }
        public bool Authenticate(Login login)
        {
            return loginController.Authenticate(login);
        }
        public bool ForgotDetails(string email)
        {
            return loginController.ForgotDetails(email);
        }
        public Tuple<Login, int> FindAccount(string what, int by)
        {
            return loginController.FindAccount(what, by);
        }
        public bool UpdateAccount(int id, Login login)
        {
            return loginController.UpdateAccount(id, login);
        }
        public bool DeleteAccount(Login login)
        {
            return loginController.DeleteAccount(login);
        }
        #endregion

        #region profile
        public bool CreateProfile(Profile profile)
        {
            return profileController.CreateProfile(profile);
        }
        public Profile ReadProfile(string what, int by)
        {
            return profileController.ReadProfile(what, by);
        }
        public bool UpdateProfile(int profileId, Profile profile)
        {
            return profileController.UpdateProfile(profileId, profile);
        }
        #endregion
    }
}
