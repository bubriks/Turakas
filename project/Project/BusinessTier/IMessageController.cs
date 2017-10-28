using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace BusinessTier
{
    public interface IMessageController
    {
        bool CreateMessage(int profileId, String text, int chatId);
        List<Message> GetMessages(int chatId);
        bool DeleteMessage(int id);
    }
}
