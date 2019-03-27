using System;

namespace MathematicalOperations
{
    /// <summary>
    /// Provides methods that implement mathemetical algorithms.
    /// </summary>
    public static class MathOperations
    {
        #region Find N Root 

        /// <summary>
        /// Returns N root of number.
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <param name="radicalSign">Radical.</param>
        /// <param name="accuracy">Accuracy.</param>
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

        #endregion

        #region GCD methods 
        public static int EuclidianGCD(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException();
            }
            uint firstNumber = (uint)a;
            uint secondNumber = (uint)b;
            while (secondNumber != 0)
            {
                uint t = firstNumber % secondNumber;
                firstNumber = secondNumber;
                secondNumber = t;
            }
            return (int)firstNumber;
        }

        public static int EuclidianGCD(int a, int b, int c)
        {
            CheckThreeGCDArguments(ref a, b, ref c);
            return EuclidianGCD(EuclidianGCD(a, b), c);
        }

        private static void CheckThreeGCDArguments(ref int a, int b, ref int c)
        {
            if (a == 0 && b == 0 && c != 0)
            {
                a = c;
            }
        }

        #endregion
    }
}
