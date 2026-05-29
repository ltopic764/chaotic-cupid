using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubCupid.Core.Models;
using PubSubCupid.Core.Randomness;

namespace PubSubCupid.Core.Matching
{
    public static class CupidScoring
    {
        // Racunamo score osobe kojoj da posaljemo pismo
        public static int CalculateScore(SinglePerson person, SinglePerson candidate)
        {
            int score = 0;

            // Isti grad
            if (person.City == candidate.City)
            {
                score += 30;
            }

            // Godine +-2
            int ageDifference = System.Math.Abs(person.Age - candidate.Age);

            if (ageDifference <= 2)
            {
                score += 20;
            }

            // Nasumican faktor
            score += SecureRandomPoints.Next(0, 101);

            return score;
        }

    }
}
