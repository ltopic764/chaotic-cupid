using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using PubSubCupid.Contracts.ServiceContracts;
using PubSubCupid.Contracts.TransferObjects;
using PubSubCupid.PersonConsole.Callback;
using PubSubCupid.PersonConsole.Input;

namespace PubSubCupid.PersonConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Callback
            // ovo ce server koristiti da posalje pismo klijentu
            PersonInboxCallback callback = new PersonInboxCallback();

            // Instance context
            // ako stigne callback, kojoj klasi da ga prosledi
            InstanceContext context = new InstanceContext(callback);

            // Proxy
            DuplexChannelFactory<ICupidDesk> factory = new DuplexChannelFactory<ICupidDesk>(context, "CupidEndpoint");
            ICupidDesk proxy = factory.CreateChannel();

            // citaj korisnicki unos
            ProfileDTO profile = ConsoleProfileReader.ReadProfile();

            bool success = proxy.InitSinglePerson(profile);

            // rez
            if (success)
            {
                Console.WriteLine("Registration successful");
            }
            else
            {
                Console.WriteLine("Username already exists");
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit");

            Console.ReadLine();
        }
    }
}
