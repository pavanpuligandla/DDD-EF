using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Encryption
{
    public static class PasswordHasher
    {
        public static string ComputeHash(string plainText)
        {
            return PasswordHasher.ComputeHash(plainText, null);
        }

        public static bool VerifyHash(string plainText, string hashValue)
        {
            byte[] array = Convert.FromBase64String(hashValue);
            int num = 256;
            int num2 = num / 8;
            if (array.Length < num2)
            {
                return false;
            }
            byte[] array2 = new byte[array.Length - num2];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = array[num2 + i];
            }
            string b = PasswordHasher.ComputeHash(plainText, array2);
            return hashValue == b;
        }

        private static string ComputeHash(string plainText, byte[] saltBytes)
        {
            if (saltBytes == null)
            {
                int minValue = 4;
                int maxValue = 8;
                Random random = new Random();
                int num = random.Next(minValue, maxValue);
                saltBytes = new byte[num];
                RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
                rNGCryptoServiceProvider.GetNonZeroBytes(saltBytes);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            byte[] array = new byte[bytes.Length + saltBytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                array[i] = bytes[i];
            }
            for (int j = 0; j < saltBytes.Length; j++)
            {
                array[bytes.Length + j] = saltBytes[j];
            }
            HashAlgorithm hashAlgorithm = new SHA256Managed();
            byte[] array2 = hashAlgorithm.ComputeHash(array);
            byte[] array3 = new byte[array2.Length + saltBytes.Length];
            for (int k = 0; k < array2.Length; k++)
            {
                array3[k] = array2[k];
            }
            for (int l = 0; l < saltBytes.Length; l++)
            {
                array3[array2.Length + l] = saltBytes[l];
            }
            return Convert.ToBase64String(array3);
        }
    }
}
