using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTier
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceReference.IService service = new ServiceReference.ServiceClient();
            Console.WriteLine(service.GetPersonsInChat(1));
        }
    }
}
