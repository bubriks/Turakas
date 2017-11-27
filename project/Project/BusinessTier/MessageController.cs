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
                if (text.Equals(""))//if message is empty
                {
                    return null;
                }

                Message message = dbMessage.CreateMessage(profileId, text, chatId);
                if (message == null)//null is returned if no changes were made
                {
                    return null;
                }
                return message;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Message> GetMessages(int chatId)
        {
            try
            {
                return dbMessage.GetMessages(chatId);//returns list of messages
            }
            catch (Exception)
            {
                return new List<Message>();//returns empty list
            }
        }

        public bool DeleteMessage(int profileId, int id)
        {
            try
            {
                if (dbMessage.DeleteMessage(profileId, id) < 1)//if no changes made
                {
                    return false;
                }
                else//changes were done
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
