using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;
using System.Transactions;

namespace BusinessTier
{
    public class MessageController: IMessageController
    {
        private DbMessage dbMessage= null;

        public MessageController()
        {
            dbMessage = new DbMessage();
        }

        public bool CreateMessage(int profileId, String text, int chatId)
        {//transacrion not workin (creates separeatly)
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    dbMessage.CreateMessage(profileId, text, chatId);
                    return true;
                }
                catch (Exception)
                {
                    ts.Dispose();
                    return false;
                }
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
                dbMessage.DeleteMessage(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
