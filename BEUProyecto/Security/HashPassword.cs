using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BEUProyecto.Security
{
    public class HashPassword
    {
        public static string CreateHashPassword(string psw)
        {
            //Create the salt value with a cryptographic PRNG:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //Create the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(psw, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            //Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //Turn the combined salt+hash into a string for storage
            string pswHash = Convert.ToBase64String(hashBytes);
            return pswHash;
        }

        public static bool VerifyPassword(string pswSaved, string pswEntered)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(pswSaved);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(pswEntered, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                    //throw new UnauthorizedAccessException();
                }
            }
            return true;
        }
    }
}
