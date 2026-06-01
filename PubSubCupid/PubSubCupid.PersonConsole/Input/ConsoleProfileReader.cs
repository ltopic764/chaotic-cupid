using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubCupid.Contracts.TransferObjects;
using System.Text.RegularExpressions;

namespace PubSubCupid.PersonConsole.Input
{
    public static class ConsoleProfileReader
    {
        public static ProfileDTO ReadProfile()
        {
            string username = ReadRequiredText("Enter username: ");
            string city = ReadRequiredText("Enter city: ");
            int age = ReadPositiveNumber("Enter age: ");
            string phone = ReadPhoneNumber("Enter phone number: ");

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

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty");
                    continue;
                }

                input = input.Trim();

                if (!Regex.IsMatch(input, @"^[A-Za-zČĆŽŠĐčćžšđ\s]+$"))
                {
                    Console.WriteLine("Only letters are allowed");
                    continue;
                }

                return input;
            }
        }

        private static string ReadPhoneNumber(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Phone number cannot be empty");
                    continue;
                }

                input = input.Trim();

                if (!Regex.IsMatch(input, @"^[0-9]+$"))
                {
                    Console.WriteLine("Phone number can contain only digits");
                    continue;
                }

                return input;
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
