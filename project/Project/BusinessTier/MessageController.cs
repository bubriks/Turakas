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
        private SqlTransaction transaction=null;

        public MessageController()
        {
            dbMessage = new DbMessage();
        }

        public bool CreateMessage(int profileId, String text, int chatId)
        {
            transaction = DbConnection.GetInstance().GetConnection().BeginTransaction();
            try
            {
                dbMessage.CreateMessage(profileId, text, chatId, transaction);
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }

        public Message GetMessage(int id)
        {
            try
            {
                return dbMessage.GetMessage(id);
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
                return dbMessage.GetMessages(chatId);
            }
            catch (Exception)
            {
                return new List<Message>();
            }
        }

        public bool DeleteMessage(int id)
        {
            try
            {
                if (dbMessage.DeleteMessage(id) == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
