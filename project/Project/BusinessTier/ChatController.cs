using DataTier;
using DataAccessTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier
{
    class ChatController
    {
        private static DbConnection con = null;
        private static DbChat dbChat = null;

        public ChatController()
        {
            con = DbConnection.GetInstance();
            dbChat = new DbChat(con);
        }

        static void Main(string[] args)
        {
            con = DbConnection.GetInstance();
            dbChat = new DbChat(con);

            con.StartTransaction();
            if(dbChat.UpdateChat(new Chat(1, "TestChat", true)))
            {
                Console.WriteLine("done");
            }
            //con.Commmit();
        }
    }
}
