using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MathematicalOperations.Test
{
    public class MathOperationsTests
    {
        #region FindNthRoot tests 

        [TestCase(-1.5)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1.5)]
        public void FindNthRoot_AccuracyIsOutOfRange_ThrowArgumentOutOfRangeException(double accuracy) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => MathOperations.FindNthRoot(0.02, 5, accuracy));

        [TestCase(-0.05454, 4)]
        [TestCase(-0.01, 2)]
        public void FindNthRoot_NegativeNumberAndEvenSign_ThrowArgumentException(double number, int radicalSign)
        {
            Assert.Throws<ArgumentException>(() => MathOperations.FindNthRoot(number, radicalSign, 0.0001));
        }

        [TestCase(-5)]
        [TestCase(0)]
        public void FindNthRoot_NotPositiveRadicalSign_ThrowArgumentException(int radicalSign)
        {
            Assert.Throws<ArgumentException>(() => MathOperations.FindNthRoot(0.0014, radicalSign, 0.0001));
        }

        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_ConcreteRadicalAndNumber_ReturnRoot(double number, int radicalSign, double accuracy, double expected)
        {
            Assert.AreEqual(expected, MathOperations.FindNthRoot(number, radicalSign, accuracy), accuracy);
        }

        #endregion

        #region GCD tests
        [TestCase(10, 25, 15, ExpectedResult = 5)]
        [TestCase(0, 0, 1, ExpectedResult = 1)]
        public static int EuclidianGCD_ThreeNumbers_ReturnResult(int a, int b , int c)
        {
            return MathOperations.EuclidianGCD(a, b, c);
        }
        
        [Test]
        public static void EuclidianGCD_ThreeNumbersAreZeros_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => MathOperations.EuclidianGCD(0, 0, 0));

        #endregion
    }
}
