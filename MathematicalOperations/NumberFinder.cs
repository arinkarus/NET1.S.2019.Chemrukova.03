using System;
using System.Collections.Generic;

namespace MathematicalOperations
{
    /// <summary>
    /// Contains method for finding next bigger integer for given integer value.
    /// </summary>
    public static class NumberFinder
    {
        /// <summary>
        /// Finds the smallest number that has same set of digits as given number and is greater than it. 
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <returns>Next bigger number or null.</returns>
        /// <exception cref="ArgumentException">Thrown when given number isn't positive.</exception>
        public static int? NextBiggerThan(int number)
        {
            CheckNumber(number);
            int i = 0;
            var digits = ConvertNumberToArrayOfDigits(number);
            for (i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    break;
                }
            }

            if (i == 0)
            {
                return null;
            }

            int minFromRightIndex = i;
            for (int j = i + 1; j < digits.Length; j++)
            {
                if ((digits[j] < digits[minFromRightIndex]) && (digits[j] > digits[i - 1]))
                {
                    minFromRightIndex = j;
                }
            }

            SwapDigits(ref digits[i - 1], ref digits[minFromRightIndex]);
            Array.Sort(digits, i, digits.Length - i);
            try
            {
                return ConvertArrayOfDigitsToNumber(digits);
            }
            catch (OverflowException)
            {
                return null;
            }
        }

        private static int[] ConvertNumberToArrayOfDigits(int number)
        {
            var digits = new List<int>();
            for (; number != 0; number /= 10)
            {
                digits.Add(number % 10);
            }

            var array = digits.ToArray();
            Array.Reverse(array);
            return array;
        }

        private static int ConvertArrayOfDigitsToNumber(int[] digits)
        {
            checked
            {
                int number = 0;
                for (int i = 0; i < digits.Length; i++)
                {
                    number = (number * 10) + digits[i];
                }

                return number;
            }
        }

        private static void SwapDigits(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        private static void CheckNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException($"Number: {nameof(number)} has to be a positive value!");
            }
        }
    }
}
