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
            Console.WriteLine("What you can do now:");
            Console.WriteLine("/confirm - confirm received love letter");
            Console.WriteLine("/block 'username' - block a user to not receive letters from them");
            Console.WriteLine("/help");
            Console.WriteLine("/exit - close application");
            Console.WriteLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "/confirm")
                {
                    proxy.ConfirmPreviousLetter(profile.Username);
                }
                else if (command == "/exit")
                {
                    break;
                }
                else if (command.StartsWith("/block "))
                {
                    string blockedUsername = command.Substring("/block ".Length).Trim();

                    if (string.IsNullOrWhiteSpace(blockedUsername))
                    {
                        Console.WriteLine("Usage: /block 'username'");
                        continue;
                    }

                    bool blocked = proxy.BlockPerson(profile.Username, blockedUsername);

                    if (blocked)
                    {
                        Console.WriteLine($"You blocked {blockedUsername}");
                    }
                    else
                    {
                        Console.WriteLine("Cannot block this user. User does not exist or input is invalid");
                    }
                }
                else if (command == "/help")
                {
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("/confirm - confirm received love letter");
                    Console.WriteLine("/block 'username' - block a user");
                    Console.WriteLine("/exit - close application");
                }
                else
                {
                    Console.WriteLine("Unknow command");
                }
            }

        }
    }
}
