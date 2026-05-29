using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubCupid.Contracts.ServiceContracts;
using PubSubCupid.Contracts.TransferObjects;

namespace PubSubCupid.Core.Models
{
    public class SinglePerson
    {
        public string Username { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Phonenumber { get; set; }

        public ISinglePersonCallback Callback { get; set; }

        // Korisnik jos nije potvrdio prethodno pisemo
        public bool WaitingForConfirmation { get; set; }

        // Lista blokiranih korisnika
        public HashSet<string> BlockedUsernames { get; set; }

        public SinglePerson()
        {
            BlockedUsernames = new HashSet<string>();
            WaitingForConfirmation = false;
        }

        // helper
        // mapiranje dto na model
        public static SinglePerson FromDTO(ProfileDTO dto, ISinglePersonCallback callback)
        {
            return new SinglePerson
            {
                Username = dto.Username,
                City = dto.City,
                Age = dto.Age,
                Phonenumber = dto.Phonenumber,

                Callback = callback
            };
        }
    }
}
