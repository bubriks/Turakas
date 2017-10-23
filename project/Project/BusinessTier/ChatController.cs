using DataTier;
using DataAccessTier;
using System;

namespace BusinessTier
{
    class ChatController
    {
        private static DbChat dbChat = null;

        public ChatController()
        {
            dbChat = new DbChat();
        }

        static void Main(string[] args)
        {
            dbChat = new DbChat();

            if (dbChat.UpdateChat(new Chat(1, "Name44", true)))
            {
                Console.WriteLine("done");
            }
        }
    }
}
