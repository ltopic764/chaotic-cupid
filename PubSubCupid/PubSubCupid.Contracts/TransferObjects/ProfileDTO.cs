using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PubSubCupid.Contracts.TransferObjects
{
    // Klasa koja predstavlja korisnikov profil
    // Definisemo ugovor o podacima
    // Kazemo da se ova klasa sme slati kroz mrezu
    [DataContract]
    public class ProfileDTO
    {
        // Sa DataMember oznacavamo sva polja klase koja se salju kroz mrezu
        // Ona polja koja nemaju ovaj atribut se ne salju

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Phonenumber { get; set; }

    }
}
