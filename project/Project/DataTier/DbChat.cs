using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    class DbChat
    {
        private static DbConnection con = null;

        public DbChat()
        {
            con = DbConnection.GetInstance();
        }

        public bool AddChat(Chat chat)
        {
            try
            {
                string stmt ="";
                SqlCommand cmd = new SqlCommand(stmt, con.GetConnection());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
