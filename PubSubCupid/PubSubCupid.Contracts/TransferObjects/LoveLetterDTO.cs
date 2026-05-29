using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PubSubCupid.Contracts.TransferObjects
{
    [DataContract]
    public class LoveLetterDTO
    {

        // Username osobe od koje nam stize pismo
        [DataMember]
        public string FromUsername { get; set; }

        // Grad osobe od koje nam stize pismo
        public string FromCity { get; set; }

        // Godine osobe od koje nam stize pisemo
        [DataMember]
        public int FromAge { get; set; }

        // Telefon se ne salje uvek
        // Ako nismo zainteresovani za upoznavanje ono je null
        [DataMember]
        public string FromPhonenumber { get; set; }

        // Tekst same poruke
        [DataMember]
        public string CupidMessage { get; set; }
    }
}
