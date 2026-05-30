using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubCupid.Contracts.TransferObjects;

namespace PubSubCupid.PersonConsole.Input
{
    public static class ConsoleProfileReader
    {
        public static ProfileDTO ReadProfile()
        {
            string username = ReadRequiredText("Enter username: ");
            string city = ReadRequiredText("Enter city: ");
            int age = ReadPositiveNumber("Enter age: ");
            string phone = ReadRequiredText("Enter phone number: ");

            return new ProfileDTO
            {
                Username = username,
                City = city,
                Age = age,
                Phonenumber = phone
            };
        }

        private static string ReadRequiredText(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.WriteLine("Input cannot be empty");
            }
        }

        private static int ReadPositiveNumber(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine();

                int number;

                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }

                if (number <= 0)
                {
                    Console.WriteLine("Number must be positive");
                    continue;
                }

                return number;
            }
        }
    }
}
