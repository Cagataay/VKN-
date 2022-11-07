using System;

namespace Vkn_Son
{
    class Program
    {
        
        
            public static bool IsVKN(string vkn)
            {
                if (string.IsNullOrEmpty(vkn) || vkn.Length != 10 || !Int64.TryParse(vkn, out Int64 vknAsInt))
                {
                    return false;
                }

                int sum = 0;
                char[] chars = vkn.ToCharArray();
                int[] digits = Array.ConvertAll(chars, c => (int)Char.GetNumericValue(c));
                int[] calculatedDigits1 = new int[9];
                int[] calculatedDigits2 = new int[9];

                for (int i = 0; i < digits.Length - 1; i++)
                {
                    calculatedDigits1[i] = (digits[i] + 10 - (i + 1)) % 10;

                    if (calculatedDigits1[i] != 9)
                    {
                        calculatedDigits2[i] = (int)((calculatedDigits1[i] * Math.Pow(2, 10 - (i + 1))) % 9);
                    }
                    else
                    {
                        calculatedDigits2[i] = 9;
                    }

                    sum += calculatedDigits2[i];
                }

                int controlDigit = (10 - (sum % 10)) % 10;
                int lastDigit = digits[digits.Length - 1];

                return controlDigit == lastDigit;
            }
        static void Main(string[] args) {
            bool err = IsVKN("3051131624");
            Console.WriteLine(err ? "true" : "false");
        }
        }
    }

