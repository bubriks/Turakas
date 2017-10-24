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
        Chat CreateChat(Chat chat);
        Chat GetChat(int id);
        bool UpdateChat(Chat chat);
        bool DeleteChat(int id);
    }
}
