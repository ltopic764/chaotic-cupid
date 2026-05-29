using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubCupid.Core.Models
{
    public class MatchScore
    {
        // Osoba koja je kandidat
        public SinglePerson Candidate { get; set; }
        public int Score { get; set; }
    }
}
