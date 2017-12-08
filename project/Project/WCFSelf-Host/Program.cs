using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFSelf_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service started");
            while (!Console.ReadLine().Equals("kill"))
            {
                Console.WriteLine("Write 'kill' to kill the service");
            }
            Console.WriteLine("Killing service...");
        }
    }
}
