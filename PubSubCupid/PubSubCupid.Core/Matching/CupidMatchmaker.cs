using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubCupid.Core.Models;

namespace PubSubCupid.Core.Matching
{
    public static class CupidMatchmaker
    {
        // Pronalazimo najbolji match
        public static MatchScore FindBestMatch(SinglePerson person, IEnumerable<SinglePerson> allPeople)
        {
            MatchScore bestMatch = null;

            foreach (SinglePerson candidate in allPeople)
            {
                // Ne sme slati sam sebi pisma
                if (candidate.Username == person.Username)
                {
                    continue;
                }

                // Da li je neko od svih ljudi u sistemu blokiran
                if (person.BlockedUsernames.Contains(candidate.Username))
                {
                    continue;
                }

                // Cekamo da korisnik potvrdi da je primio pismo
                if (candidate.WaitingForConfirmation)
                {
                    continue;
                }

                int score = CupidScoring.CalculateScore(person, candidate);

                if (bestMatch == null || score > bestMatch.Score)
                {
                    bestMatch = new MatchScore { Candidate = candidate, Score = score };
                } 
            }

            return bestMatch;
        }
    }
}
