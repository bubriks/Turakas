using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace PresentationTier
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceReference.IService service = new ServiceReference.ServiceClient();
            foreach (Chat chat in service.GetChatsByName("chat"))
            {
                Console.WriteLine(chat.Name);
            }
        }
    }
}
