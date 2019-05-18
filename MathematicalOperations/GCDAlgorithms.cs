using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalOperations
{
    /// <summary>
    /// Static class that provides methods for calculating greatest common divider.
    /// </summary>
    public static class GCDAlgorithms
    {
        #region Public methods for Euclidiean

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetEuclidieanGcd(int firstNumber, int secondNumber) =>
            GcdWith2Params(firstNumber, secondNumber, new EuclidieanAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="time">Time of calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetEuclidieanGcd(out long time, int firstNumber, int secondNumber) =>
            GcdWith2ParamsAndTime(out time, firstNumber, secondNumber, new EuclidieanAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetEuclidieanGcd(int firstNumber, int secondNumber, int thirdNumber) =>
            GcdWith3Params(firstNumber, secondNumber, thirdNumber, new EuclidieanAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="time">Time of calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetEuclidieanGcd(out long time, int firstNumber, int secondNumber, int thirdNumber) =>
            GcdWith3ParamsAndTime(out time, firstNumber, secondNumber, thirdNumber, new EuclidieanAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="numbers">Array of parameters.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetEuclidieanGcd(params int[] numbers) =>
            GcdWithArray(numbers, new EuclidieanAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="time">Time of calculations.</param>
        /// <param name="numbers">Array of parameters.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetEuclidieanGcd(out long time, int[] numbers) =>
            GcdWithArrayAndTime(out time, numbers, new EuclidieanAlgorithm());

        #endregion

        #region Public methods for Stein

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetSteinGcd(int firstNumber, int secondNumber) =>
            GcdWith2Params(firstNumber, secondNumber, new SteinAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="time">Time of calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetSteinGcd(out long time, int firstNumber, int secondNumber) =>
            GcdWith2ParamsAndTime(out time, firstNumber, secondNumber, new SteinAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetSteinGcd(int firstNumber, int secondNumber, int thirdNumber) =>
            GcdWith3Params(firstNumber, secondNumber, thirdNumber, new SteinAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="time">Time of calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetSteinGcd(out long time, int firstNumber, int secondNumber, int thirdNumber) =>
            GcdWith3ParamsAndTime(out time, firstNumber, secondNumber, thirdNumber, new SteinAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="numbers">Array of parameters.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetSteinGcd(params int[] numbers) =>
            GcdWithArray(numbers, new SteinAlgorithm());

        /// <summary>
        /// Returns greatest common divider.
        /// </summary>
        /// <param name="time">Time of calculations.</param>
        /// <param name="numbers">Array of parameters.</param>
        /// <returns>Calculated greatest common divider.</returns>
        /// <exception cref="ArgumentException">Thrown when greatest common divider
        /// can't be calculated.</exception>
        public static int GetSteinGcd(out long time, int[] numbers) =>
            GcdWithArrayAndTime(out time, numbers, new SteinAlgorithm());

        #endregion

        #region Private static methods

        private static int GcdWith2Params(int first, int second, GCDAlgorithm algorithm) =>
            algorithm.Calculate(first, second);

        private static int GcdWith2ParamsAndTime(out long time, int first, int second, GCDAlgorithm algorithm) =>
            algorithm.Calculate(out time, first, second);

        private static int GcdWith3Params(int first, int second, int third, GCDAlgorithm algorithm) =>
            algorithm.Calculate(first, second, third);

        private static int GcdWith3ParamsAndTime(out long time, int first, int second, int third, GCDAlgorithm algorithm) =>
            algorithm.Calculate(out time, first, second, third);

        private static int GcdWithArray(int[] numbers, GCDAlgorithm algorithm) =>
            algorithm.Calculate(numbers);

        private static int GcdWithArrayAndTime(out long time, int[] numbers, GCDAlgorithm algorithm) =>
            algorithm.Calculate(out time, numbers);

        #endregion
    }
}
