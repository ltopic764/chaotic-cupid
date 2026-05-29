using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PubSubCupid.Core.Randomness
{
    public static class SecureRandomPoints
    {
        public static int Next(int min, int max)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[4];

                rng.GetBytes(randomBytes);

                int randomNumber = System.BitConverter.ToInt32(randomBytes, 0);

                if (randomNumber < 0)
                {
                    randomNumber = -randomNumber;
                }

                int range = max - min;

                return min + (randomNumber % range);
            }
        }
    }
}
