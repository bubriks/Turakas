using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;
using System.Data.SqlClient;
using System.Data;

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
        
        public Message CreateMessage(int profileId, string text, int chatId)
        {
            try
            {
                if (text.Equals(""))//if message is empty
                {
                    return null;
                }
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    using (IDbTransaction tran = con.BeginTransaction())
                    {
                        try
                        {
                            int activityId = dbActivity.CreateActivity(profileId, (SqlTransaction)tran, con);
                            Message message = dbMessage.CreateMessage(activityId, text, chatId, (SqlTransaction)tran, con);
                            if (message == null)
                            {
                                tran.Rollback();
                                return null;
                            }
                            else
                            {
                                tran.Commit();
                                return message;
                            }
                        }
                        catch
                        {
                            tran.Rollback();
                            return null;
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
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
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    return dbMessage.GetMessages(chatId, null, con);//returns list of messages
                }
                finally
                {
                    con.Close();
                }
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
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    if (dbActivity.DeleteActivity(profileId, id, null, con) == 1)//if no changes made
                    {
                        return true;
                    }
                    else//changes were done
                    {
                        return false;
                    }
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
