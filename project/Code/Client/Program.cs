using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static ServiceReference.IProjectService chatObj = new ServiceReference.ProjectServiceClient();
        static void Main(string[] args)
        {
            String a=Console.ReadLine();
            Console.WriteLine(chatObj.SendText(a));
        }
    }
}
