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
        private DbMessage dbMessage = null;
        private DbActivity dbActivity = null;

        public MessageController()
        {
            dbMessage = new DbMessage();
            dbActivity = new DbActivity();
        }
        
        public Message CreateMessage(int profileId, String text, int chatId)
        {
            try
            {
                if (text.Equals(""))//if message is empty
                {
                    return null;
                }
                
                return dbMessage.CreateMessage(dbActivity.CreateActivity(profileId), text, chatId);
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
                if (dbActivity.DeleteActivity(profileId, id) == 0)//if no changes made
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
