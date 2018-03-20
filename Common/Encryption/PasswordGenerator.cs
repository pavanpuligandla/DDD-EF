using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Encryption
{
    public static class PasswordGenerator
    {
        

        private static string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";

        private static string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";

        private static string PASSWORD_CHARS_NUMERIC = "23456789";

        private static string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";

        public static string Generate()
        {
            return PasswordGenerator.Generate(8, 10);
        }

        public static string Generate(int length)
        {
            return PasswordGenerator.Generate(length, length);
        }

        public static string Generate(int minLength, int maxLength)
        {
            if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
            {
                return null;
            }
            char[][] array = new char[][]
            {
                PASSWORD_CHARS_LCASE.ToCharArray(),
                PASSWORD_CHARS_UCASE.ToCharArray(),
                PASSWORD_CHARS_NUMERIC.ToCharArray(),
                PASSWORD_CHARS_SPECIAL.ToCharArray()
            };
            int[] array2 = new int[array.Length];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = array[i].Length;
            }
            int[] array3 = new int[array.Length];
            for (int j = 0; j < array3.Length; j++)
            {
                array3[j] = j;
            }
            byte[] array4 = new byte[4];
            RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
            rNGCryptoServiceProvider.GetBytes(array4);
            int seed = (int)(array4[0] & 127) << 24 | (int)array4[1] << 16 | (int)array4[2] << 8 | (int)array4[3];
            Random random = new Random(seed);
            char[] array5;
            if (minLength < maxLength)
            {
                array5 = new char[random.Next(minLength, maxLength + 1)];
            }
            else
            {
                array5 = new char[minLength];
            }
            int num = array3.Length - 1;
            for (int k = 0; k < array5.Length; k++)
            {
                int num2;
                if (num == 0)
                {
                    num2 = 0;
                }
                else
                {
                    num2 = random.Next(0, num);
                }
                int num3 = array3[num2];
                int num4 = array2[num3] - 1;
                int num5;
                if (num4 == 0)
                {
                    num5 = 0;
                }
                else
                {
                    num5 = random.Next(0, num4 + 1);
                }
                array5[k] = array[num3][num5];
                if (num4 == 0)
                {
                    array2[num3] = array[num3].Length;
                }
                else
                {
                    if (num4 != num5)
                    {
                        char c = array[num3][num4];
                        array[num3][num4] = array[num3][num5];
                        array[num3][num5] = c;
                    }
                    array2[num3]--;
                }
                if (num == 0)
                {
                    num = array3.Length - 1;
                }
                else
                {
                    if (num != num2)
                    {
                        int num6 = array3[num];
                        array3[num] = array3[num2];
                        array3[num2] = num6;
                    }
                    num--;
                }
            }
            return new string(array5);
        }
    }
}
