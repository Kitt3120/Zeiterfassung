using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassung.Models.Person;

namespace Zeiterfassung.Utils
{
    public static class HashUtils
    {
        /// <summary>
        /// Generiert einen Hash
        /// </summary>
        /// <param name="input">Der zu verwendene Input</param>
        /// <returns></returns>
        public static string GenerateHash(string input)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            byte[] hash = new Rfc2898DeriveBytes(input, salt, 10000).GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Überprüft einen Hash
        /// </summary>
        /// <param name="input">Der zu verwendene Input</param>
        /// <param name="savedHash">Der existierende Hash zum Abgleichen</param>
        /// <returns></returns>
        public static bool Verify(string input, string savedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(savedHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            byte[] inputHash = new Rfc2898DeriveBytes(input, salt, 10000).GetBytes(20);

            bool inputCorrect = true;
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != inputHash[i])
                    inputCorrect = false;

            return inputCorrect;
        }
    }
}