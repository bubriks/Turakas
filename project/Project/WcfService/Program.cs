using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service started");
            ServiceHost serviceHost = new ServiceHost(typeof(ChatService));
            serviceHost.Open();
            ServiceHost serviceHost1 = new ServiceHost(typeof(GameService));
            serviceHost1.Open();
            ServiceHost serviceHost2 = new ServiceHost(typeof(GroupService));
            serviceHost2.Open();
            ServiceHost serviceHost3 = new ServiceHost(typeof(MessageService));
            serviceHost3.Open();
            ServiceHost serviceHost4 = new ServiceHost(typeof(ProfileService));
            serviceHost4.Open();
            ServiceHost serviceHost5 = new ServiceHost(typeof(YoutubeService));
            serviceHost5.Open();
            DisplayHostInfo(serviceHost);
            DisplayHostInfo(serviceHost1);
            DisplayHostInfo(serviceHost2);
            DisplayHostInfo(serviceHost3);
            DisplayHostInfo(serviceHost4);
            DisplayHostInfo(serviceHost5);

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press the Enter key to terminate service.");
            Console.ReadLine();
        }
        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine(); Console.WriteLine("****** Host Info *******");
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding.Name);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
                Console.WriteLine("Instance Context Menu: {0}", host.Description.Behaviors.Find<ServiceBehaviorAttribute>().InstanceContextMode);
                Console.WriteLine("Concurrency Mode: {0}", host.Description.Behaviors.Find<ServiceBehaviorAttribute>().ConcurrencyMode);
                Console.WriteLine();
            }
            Console.WriteLine("************************");
            Console.WriteLine();
        }
    }
}
