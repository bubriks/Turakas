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
        /// <summary>
        /// Creates profiles message in specific chat
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="text"></param>
        /// <param name="chatId"></param>
        /// <returns></returns>
        bool CreateMessage(int profileId, String text, int chatId);
        /// <summary>
        /// Gets specific message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Message GetMessage(int id);
        /// <summary>
        /// Gets last 20 messages in chat
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        List<Message> GetMessages(int chatId);
        /// <summary>
        /// Deletes message from chat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteMessage(int id);
    }
}
