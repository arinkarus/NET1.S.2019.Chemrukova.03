using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalOperations
{
    /// <summary>
    /// Abstract class that provide methods that calculate greatest common divider.
    /// </summary>
    internal abstract class GCDAlgorithm
    {
        /// <summary>
        /// Calculates greatest common divider.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when all elements are 0.</exception>
        public int Calculate(int a, int b)
        {
            CheckNumbers(a, b);
            SetNumbersToAbsoluteValue(ref a, ref b);            
            return this.Gcd(a, b);
        }

        /// <summary>
        /// Calculates greatest common divider.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when all elements are 0.</exception>
        public int Calculate(int a, int b, int c)
        {
            MoveArguments(ref a, b, ref c);
            return Calculate(a, b);
        }

        /// <summary>
        /// Calculates greatest common divider.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when all elements are 0.</exception>
        public int Calculate(params int[] numbers)
        {
            CheckNumbers(numbers);
            Array.Sort(numbers, new ReverseComparer());
            int gcd = this.Calculate(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length && gcd != 1; i++)
            {
                gcd = Calculate(gcd, numbers[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Calculates greatest common divider.
        /// </summary>
        /// <param name="time">Time of method's execution.</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when all elements are 0.</exception>
        public int Calculate(out long time, int a, int b)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = this.Calculate(a, b);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Calculates greatest common divider.
        /// </summary>
        /// <param name="time">Time of method's execution.</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when all elements are 0.</exception>
        public int Calculate(out long time, int a, int b, int c)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = this.Calculate(a, b, c);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Calculates greatest common divider.
        /// </summary>
        /// <param name="time">Time of method's execution.</param>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when all elements are 0.</exception>
        public int Calculate(out long time, params int[] numbers)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = Calculate(numbers);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        private static void CheckNumbers(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException($"Array cannot be null {nameof(numbers)}.");
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException($"Array has to have minumum 2 elements: {nameof(numbers)}.");
            }
        }

        private void CheckNumbers(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException($"GCD cannot be calculated for both zero args: {nameof(a)} and {nameof(b)}");
            }

            if (a == int.MinValue && b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"GCD for {nameof(a)} and {nameof(b)} can't be calculated within integer range");
            }
        }

        private static void MoveArguments(ref int a, int b, ref int c)
        {
            if (a == 0 && b == 0 && c != 0)
            {
                a = c;
            }
        }

        private static void SetNumbersToAbsoluteValue(ref int a, ref int b)
        {
            if (a < 0)
            {
                a = -a;
            }

            if (b < 0)
            {
                b = -b;
            }
        }

        protected abstract int Gcd(int a, int b);
    }

    internal class EuclidieanAlgorithm : GCDAlgorithm
    {
        protected override int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int t = a % b;
                a = b;
                b = t;
            }

            return a;
        }
    }

    internal class SteinAlgorithm : GCDAlgorithm
    {
        protected override int Gcd(int first, int second)
        { 
            int shift;
            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            uint a = (uint)first;
            uint b = (uint)second;

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    uint t = b;
                    b = a;
                    a = t;
                }

                b = b - a;
            }
            while (b != 0);

            return (int)a << shift;
        }
    }
}
