using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract]
    public interface IService
    {
        #region chat
        [OperationContract]
        Chat CreateChat(Chat chat, int profileId);

        [OperationContract]
        List<Chat> GetChatsByName(String name);

        [OperationContract]
        bool UpdateChat(Chat chat);

        [OperationContract]
        bool DeleteChat(int id);

        [OperationContract]
        List<Chat> GetPersonsChats(int profileId);

        [OperationContract]
        List<Profile> GetPersonsInChat(int chatId);

        [OperationContract]
        bool AddPersonToChat(int chatId, int profileId);

        [OperationContract]
        bool RemovePersonFromChat(int chatId, int profileId);
        #endregion

        #region message
        [OperationContract]
        bool CreateMessage(int profileId, String text, int chatId);

        [OperationContract]
        List<Message> GetMessages(int chatId);

        [OperationContract]
        bool DeleteMessage(int id);
        #endregion

        #region login
        [OperationContract]
        bool CreateLogin(Login login);
        [OperationContract]
        bool Authenticate(Login login);
        [OperationContract]
        bool ForgotDetails(string email);
        [OperationContract]
        Tuple<Login, int> FindLogin(string what, int by);
        [OperationContract]
        bool UpdateLogin(int id, Login login);
        [OperationContract]
        bool DeleteLogin(Login login);
        #endregion

        #region profile
        [OperationContract]
        bool CreateProfile(Profile profile);
        [OperationContract]
        Profile ReadProfile(string what, int by);
        [OperationContract]
        bool UpdateProfile(int profileId, Profile profile);
        #endregion
    }
}
