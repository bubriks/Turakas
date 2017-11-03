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

        public bool CreateMessage(int profileId, String text, int chatId)
        {
            //Creates new starnsaction
            con.BeginTransaction();
            try
            {
                //passes the transaction further to DataAccessTier
                if (dbMessage.CreateMessage(profileId, text, chatId) == 0)
                {
                    //transaction is rolled back and false is returned if no changes were made
                    con.Rollback();
                    return false;
                }
                //if everything goes as planed than commited
                con.Commit();
                //returns true if everything went correctly
                return true;
            }
            catch (Exception)
            {
                //If exception is thrown the transaction is rolled back and false is returned
                con.Rollback();
                return false;
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
