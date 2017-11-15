using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;
using System.Data.SqlClient;

namespace BusinessTier
{
    public class MessageController: IMessageController
    {
        private DbMessage dbMessage= null;
        private DbConnection con = null;

        public MessageController()
        {
            dbMessage = new DbMessage();
            con = DbConnection.GetInstance();
        }

        public Message CreateMessage(int profileId, String text, int chatId)
        {
            try
            {
                Message message = dbMessage.CreateMessage(profileId, text, chatId);
                if (message == null)
                {
                    //null is returned if no changes were made
                    return null;
                }
                //returns Message if everything went correctly
                return message;
            }
            catch (Exception)
            {
                //If exception is thrown null is returned
                return null;
            }
        }

        public List<Message> GetMessages(int chatId)
        {
            try
            {
                //returns list of objects if everything went correctly
                return dbMessage.GetMessages(chatId);
            }
            catch (Exception)
            {
                //returns empty list if exception is thrown
                return new List<Message>();
            }
        }

        public bool DeleteMessage(int id)
        {
            try
            {
                if (dbMessage.DeleteMessage(id) == 0)
                {
                    //returns false if no changes were made
                    return false;
                }
                //returns true if everything went correctly
                return true;
            }
            catch (Exception)
            {
                //returns false if exception is thrown
                return false;
            }
        }
    }
}
