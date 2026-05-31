using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using PubSubCupid.CupidHost.Services;

namespace PubSubCupid.CupidHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChaoticCupidService service = new ChaoticCupidService();

            ServiceHost host = new ServiceHost(service);

            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                host.Open();

                Console.WriteLine("Cupid service started");

                string asciiArt = @"
                
                ⠀⠀⠀⠀⠀⣄⣤⣴⡶⣶⠲⣤⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢴⣿⣗⢋⣼⣿⢆⣿⠏⣼⣷⣤⡀⠀⠀
⠀⠀⠀⠀⠀⢠⡤⠤⠖⣒⡖⠒⠦⡄⠀⠀⠀⣾⣏⣿⣻⡘⣿⠿⢷⡿⣿⣄⣿⣮⣷⣷⡀⠀
⠀⢀⣀⣠⠴⣏⣉⣭⠭⠽⣶⠒⠊⣘⢦⡀⣰⣟⣙⣿⡿⣷⠟⠀⣀⣀⠉⠉⢺⠏⣿⣽⠅⠀
⠺⠭⢤⠤⠤⠒⠚⢒⣶⠒⠂⢫⣍⣡⠤⢻⠏⣻⣿⡿⣏⠁⠀⠰⢤⠌⠀⠀⣄⢱⣾⣿⠀⠀
⠀⠀⠈⢳⡶⠓⠋⣉⣠⠽⣏⣁⣸⢶⡒⢋⣳⣜⠾⢷⣏⣀⣀⠀⣠⡦⠄⠳⣶⣿⡯⠁⠀⠀
⠀⠀⠀⠀⠉⠹⠭⠭⣴⣲⡯⠷⢦⡾⠛⠫⣤⡿⠋⠉⠈⣿⢯⡷⡐⠛⠂⣠⣿⠉⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢻⣟⣉⣉⡹⡽⠋⠀⠀⠀⠳⣝⠦⡄⡈⣶⣿⣻⠏⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠿⢧⡤⣾⠇⠀⢀⠀⠀⠀⠘⣾⡇⠀⢹⠂⢹⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢩⠏⠀⠀⠀⠳⣄⠀⠀⠻⠀⠀⣸⠀⠀⡗⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⣀⣤⠞⠓⢤⣀⣀⣴⡿⣀⢼⣦⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⡹⢋⠀⠀⠀⠀⠰⠄⠀⠙⣄⠈⠙⢇⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣆⠀⠀⠀⠀⠀⠀⠀⢺⡀⠀⠀⠘⣆⠀⠘⡆⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠦⣀⠀⠀⠀⢀⣠⠾⠳⣄⠀⠀⠘⣆⠀⠹⡄⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠀⠀⠀⠀⢹⠦⠀⠈⠳⣄⠙⣦⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠳⢤⡀⢀⣈⣳⣾⡆
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠛⠋⠀
                ";

                Console.WriteLine(asciiArt);

                Console.WriteLine("Timer is running");

                Console.WriteLine("Press ENTER to stop");

                Console.WriteLine();

                Console.ReadLine();

                host.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                host.Abort();
            }
        }
    }
}
