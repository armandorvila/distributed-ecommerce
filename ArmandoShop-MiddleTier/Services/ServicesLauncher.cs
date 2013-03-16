using System;
using Spring.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel;
namespace ArmandoShop.Services
{
    class ServicesLauncher
    {
        private static readonly string HTTP_SERVICE_NAME = "HttpArmandoShopService";
        private static readonly string TCP_SERVICE_NAME = "TcpArmandoShopService";

        public void LaunchService(string service)
        {
            using (SpringServiceHost host = new SpringServiceHost(service))
            {
                Console.WriteLine("** Init Service of Armando 's Shop **");
                try
                {
                    host.Open();
                    Console.WriteLine("Host has been started");
                    Console.WriteLine("Endpoints:");
                    foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
                    {
                        Console.WriteLine("************** End Point ***************\n");
                        Console.WriteLine("Address: {0} ", endpoint.Address);
                        Console.WriteLine("Binding: {0}", endpoint.Binding);
                        Console.WriteLine("Contract: {0}", endpoint.Contract.ContractType);
                    }
                    Console.WriteLine("** Press Enter to continue...");
                    Console.ReadLine();
                    host.Close();
                }
                catch (AddressAccessDeniedException)
                {
                    Console.WriteLine("Access Denied, Run as admin please ...\n"
                    + "Press Enter to continue..\n");
                    Console.ReadLine();
                    host.Abort();
                }                            
            }
        }

        private int selectService()
        {
            Console.WriteLine("******* ArmandoSHop Services Managment App ******\n\n");
            Console.WriteLine("Select a Service to Launch \n");
            Console.WriteLine("1-Launch Armando Shop Tcp Servcie \n");
            Console.WriteLine("2-Launch Armando Shop Http Servcie \n");
            Console.WriteLine("3-Exit .. \n");
            try
            {
                int option = Int32.Parse(Console.ReadLine());
                if (option < 1 || option > 3)
                {
                    Console.WriteLine("Incorrect Option ..");
                    return selectService();
                }
                return option;
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect Option ..");
                return selectService();
            }
        }

        static void Main(string[] args)
        {
            ServicesLauncher launcher = new ServicesLauncher();
            int option = launcher.selectService();
            while (option != 3)
            {
                if (option == 1)
                    launcher.LaunchService(TCP_SERVICE_NAME);

                else if (option == 2)
                    launcher.LaunchService(HTTP_SERVICE_NAME);

                option = launcher.selectService();
            }
        }
    }
}
