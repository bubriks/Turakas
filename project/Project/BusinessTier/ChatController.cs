using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier
{
    class ChatController
    {
        private DbConnection con = null;
        private static DbChat dbChat = null;

        public ChatController()
        {
            con = DbConnection.GetInstance();
            dbChat = new DbChat(con);
        }
    }
}
