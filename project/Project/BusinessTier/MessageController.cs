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

        public MessageController()
        {
            dbMessage = new DbMessage();
        }

        public Message CreateMessage(int profileId, String text, int chatId)
        {
            try
            {
                if (text.Equals(""))
                {
                    //if message is empty
                    return null;
                }

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
                List<Message> messages = new List<Message>();
                Message message = new Message();
                message.Text = "fail";
                messages.Add(message);
                return messages;
            }
        }

        public bool DeleteMessage(int profileId, int id)
        {
            try
            {
                if (dbMessage.DeleteMessage(profileId, id) != 1)
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
