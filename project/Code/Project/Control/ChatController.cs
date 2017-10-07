using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ChatController : IChatController
    {
        private DbChat chat = new DbChat();
        public string SendText(string text)
        {
            chat.SendText(text);
            return chat.GetText();
        }
    }
}
