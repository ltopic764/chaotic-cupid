using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubCupid.Contracts.ServiceContracts;
using PubSubCupid.Contracts.TransferObjects;

namespace PubSubCupid.PersonConsole.Callback
{
    // Server poziva metode iz ove klase
    // duplex
    public class PersonInboxCallback : ISinglePersonCallback
    {

        public void ReceiveLoveLetter(LoveLetterDTO letter)
        {
            Console.WriteLine();
            Console.WriteLine("##########################");
            Console.WriteLine("NEW LOVE LETTER ARRIVED");
            Console.WriteLine($"From: {letter.FromUsername}");
            Console.WriteLine($"City: {letter.FromCity}");
            Console.WriteLine($"Age: {letter.FromAge}");
            Console.WriteLine($"Phone: {letter.FromPhonenumber}");
            Console.WriteLine($" '{letter.CupidMessage}' ");
            Console.WriteLine("##########################");
            Console.WriteLine();
        }
    }
}
