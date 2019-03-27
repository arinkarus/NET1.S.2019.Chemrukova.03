using System;
using System.Diagnostics;
using System.Threading;

namespace MathematicalOperations
{
    /// <summary>
    /// Provides methods that implement math algorithms.
    /// </summary>
    public static class MathOperations
    {
        #region Find N Root 

        /// <summary>
        /// Returns N root of number.
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <param name="radicalSign">Radical sign.</param>
        /// <param name="accuracy">Accuracy for calculations.</param>
        /// <returns>Nth root of number</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when accuracy
        /// is not in (0, 1) range.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown when radical isn't positive
        /// or when root cannot be calculated. 
        /// </exception>
        public static double FindNthRoot(double number, int radicalSign, double accuracy)
        {
            CheckRadicalSign(radicalSign);
            CheckAccuracy(accuracy);
            CheckPossibilityOfCalculation(number, radicalSign);
            double prev = 1;
            double current = GetRootValueForCurrentIteration(number, radicalSign, prev);
            while (Math.Abs(current - prev) > accuracy)
            {
                prev = current;
                current = GetRootValueForCurrentIteration(number, radicalSign, prev);
            }

            return current;
        }

        #endregion

        #region Euclidian GCD public methods

        /// <summary>
        /// Method that returns NOD of two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>GCD for first and second number.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when both args are 0 or int.MinValue.
        /// </exception>
        public static int EuclidianGCD(int a, int b)
        {
            CheckNumbers(a, b);
            SetNumbersToAbsoluteValue(ref a, ref b);

            while (b != 0)
            {
                int t = a % b;
                a = b;
                b = t;
            }

            return a;
        }

        /// <summary>
        /// Method that returns greatest common divisor of two numbers.
        /// </summary>
        /// <param name="time">Milliseconds for execution.</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Greatest common divisor for first and second number./</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when both args are 0 or int.MinValue.
        /// </exception>
        public static int EuclidianGCD(out long time, int a, int b)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = EuclidianGCD(a, b);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Method that returns NOD of three numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>GCD for three numbers.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when all numbers are 0.
        /// </exception>
        public static int EuclidianGCD(int a, int b, int c)
        {
            MoveArguments(ref a, b, ref c);
            return EuclidianGCD(EuclidianGCD(a, b), c);
        }

        /// <summary>
        /// Method that returns NOD of three numbers.
        /// </summary>
        /// <param name="time">Milliseconds for execution.</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>GCD for three numbers.</returns>
        public static int EuclidianGCD(out long time, int a, int b, int c)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = EuclidianGCD(a, b, c);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Method that returns GCD for several numbers.
        /// </summary>
        /// <param name="numbers">Array of numbers for which GCD will be found.</param>
        /// <returns>GCD for several numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array's length is less than 2
        /// or all of the numbers are 0.
        /// </exception>
        public static int EuclidianGCD(params int[] numbers)
        {
            CheckNumbers(numbers);
            Array.Sort(numbers, new ReverseComparer());
            int gcd = EuclidianGCD(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length && gcd != 1; i++)
            {
                gcd = EuclidianGCD(gcd, numbers[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Method that returns greatest common divisor for several numbers.
        /// </summary>
        /// <param name="time">Milliseconds for execution.</param>
        /// <param name="numbers">Array of numbers for which greatest common divisor will be found.</param>
        /// <returns>GCD for several numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array's length is less than 2
        /// or all of the numbers are 0.
        /// </exception>
        public static int EuclidianGCD(out long time, params int[] numbers)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = EuclidianGCD(numbers);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        #endregion

        #region Stein GCD public methods

        /// <summary>
        /// Method that returns GCD of two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>GCD of two numbers.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when both args are 0 or int.MinValue.
        /// </exception>
        public static int SteinGCD(int a, int b)
        {
            CheckNumbers(a, b);
            SetNumbersToAbsoluteValue(ref a, ref b);

            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return SteinGCD(a >> 1, b);
                }
                else
                {
                    return SteinGCD(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) != 0)
            {
                return SteinGCD(a, b >> 1);
            }

            if (a > b)
            {
                return SteinGCD((a - b) >> 1, b);
            }

            return SteinGCD((b - a) >> 1, a);
        }

        /// <summary>
        /// Method that returns GCD of two numbers.
        /// </summary>
        /// <param name="time">Milliseconds for execution.</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>GCD of two numbers.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when both args are 0 or int.MinValue.
        /// </exception>
        public static int SteinGCD(out long time, int a, int b)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = SteinGCD(a, b);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Method that returns GCD of three numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>GCD of two numbers.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when all args are 0.
        /// </exception>
        public static int SteinGCD(int a, int b, int c)
        {
            MoveArguments(ref a, b, ref c);
            return SteinGCD(SteinGCD(a, b), c);
        }

        /// <summary>
        /// Method that returns GCD of three numbers.
        /// </summary>
        /// <param name="time">Milliseconds for execution.</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>GCD of two numbers.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when all args are 0.
        /// </exception>
        public static int SteinGCD(out long time, int a, int b, int c)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = SteinGCD(a, b, c);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Method that returns greatest common divisor for several numbers.
        /// </summary>
        /// <param name="numbers">Array of numbers for which
        /// GCD will be found.
        /// </param>
        /// <returns>Greatest common divisor for given numbers.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when all elements in array are 0 or
        /// length of array is less than 2.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when array is null.
        /// </exception>
        public static int SteinGCD(params int[] numbers)
        {
            CheckNumbers(numbers);
            Array.Sort(numbers, new ReverseComparer());
            int gcd = SteinGCD(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length && gcd != 1; i++)
            {
                gcd = SteinGCD(gcd, numbers[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Method that returns GCD for several numbers.
        /// </summary>
        /// <param name="time">Milliseconds for execution.</param>
        /// <param name="numbers">Array of numbers for which
        /// GCD will be found.
        /// </param>
        /// <returns>GCD for given numbers.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when all elements in array are 0 or
        /// length of array is less than 2.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when array is null.
        /// </exception>
        public static int SteinGCD(out long time, params int[] numbers)
        {
            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            int gcd = SteinGCD(numbers);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }

        #endregion

        private static double GetRootValueForCurrentIteration(double number, int radical, double prev) =>
            ((radical - 1) * prev + number / Math.Pow(prev, radical - 1)) / radical;

        private static void CheckAccuracy(double accuracy)
        {
            if (accuracy <= 0 || accuracy >= 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(accuracy)} has to be less than 1 and greater than 0.");
            }
        }

        private static void CheckPossibilityOfCalculation(double number, int radicalSign)
        {
            if (radicalSign % 2 == 0 && number < 0)
            {
                throw new ArgumentException($"Can't calculate root for {nameof(radicalSign)} and {nameof(number)}.");
            }
        }

        private static void CheckRadicalSign(int radicalSign)
        {
            if (radicalSign <= 0)
            {
                throw new ArgumentException($"{nameof(radicalSign)} has to be a natural number.");
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

        private static void CheckNumbers(int a, int b)
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
    }
}
