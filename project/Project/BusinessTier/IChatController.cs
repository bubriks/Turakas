using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier
{
    public interface IChatController
    {
        Chat CreateChat(Chat chat, int personId);
        Chat GetChat(int id);
        List<Chat> GetChatsByName(String name);
        bool UpdateChat(Chat chat);
        bool DeleteChat(int id);
        List<Profile> GetPersonsInChat(int chatId);
        bool AddPersonToChat(int chatId, int personId);
        bool RemovePersonFromChat(int chatId, int personId);
    }
}
