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
        IRelationshipController relationshipController = new RelationshipController();
        INotificationController notificationController = new NotificationController();
        ISongController songController = new SongController();

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
        public bool CreateLogin(Login login)
        {
            return loginController.CreateLogin(login);
        }
        public bool Authenticate(Login login)
        {
            return loginController.Authenticate(login);
        }
        public bool ForgotDetails(string email)
        {
            return loginController.ForgotDetails(email);
        }
        public Login FindLogin(string what, int by)
        {
            return loginController.FindLogin(what, by);
        }
        public bool UpdateLogin(int id, Login login)
        {
            return loginController.UpdateLogin(id, login);
        }
        public bool DeleteLogin(Login login)
        {
            return loginController.DeleteLogin(login);
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

        #region relationship
        public void CreateRelationship(int profileId, RelationShip relationShip)
        {
            relationshipController.CreateRelationship(profileId, relationShip);
        }

        public List<RelationShip> ReadRelationship(string what, int by)
        {
            return relationshipController.ReadRelationship(what, by);
        }

        public bool UpdateRelationship(int id, RelationShip newRelationship)
        {
            return relationshipController.UpdateRelationship(id, newRelationship);
        }

        public bool DeleteRelationship(RelationShip relationShip)
        {
            return relationshipController.DeleteRelationship(relationShip);
        }
        #endregion

        #region notification
        
        bool IService.CreateNotification(Notification notification)
        {
            return notificationController.CreateNotification(notification);
        }

        List<Notification> IService.ReadNotification(int profileId)
        {
            return notificationController.ReadNotification(profileId);
        }

        bool IService.DeleteNotification(Notification notification)
        {
            return notificationController.DeleteNotification(notification);
        }

        bool IService.DeleteAllNotifications(int profileId)
        {
            return notificationController.DeleteAllNotifications(profileId);
        }

        #endregion
        #region youtube


        public void AddSong(int activityID, int artistID, int genreID, string name, int duration, string url)
        {
            songController.AddSong(activityID, artistID, genreID, name, duration, url);
        }
        public string GetVideoInfo(string videoId)
        {
            return songController.GetVideoInfo(videoId);

        }

        #endregion
    }
}
