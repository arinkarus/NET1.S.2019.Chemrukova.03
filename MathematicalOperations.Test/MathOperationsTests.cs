using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        #region GCD Data for test cases

        public static IEnumerable<TestCaseData> GCDThreeNumbersCases
        {
            get
            {
                yield return new TestCaseData(24654, 25473, 954).Returns(21);
                yield return new TestCaseData(15, 10, 20).Returns(5);
                yield return new TestCaseData(0, 0, 1).Returns(1);
            }
        }

        public static IEnumerable<TestCaseData> GCDTwoNumbersCases
        {
            get
            {
                yield return new TestCaseData(441, 700).Returns(7);
                yield return new TestCaseData(30, 12).Returns(6);
                yield return new TestCaseData(1, 1).Returns(1);
                yield return new TestCaseData(5, 10).Returns(5);
                yield return new TestCaseData(int.MaxValue, int.MaxValue).Returns(int.MaxValue);
                yield return new TestCaseData(int.MinValue, -1073741824).Returns(1073741824);
                yield return new TestCaseData(int.MinValue, 1).Returns(1);
            }
        }

        public static IEnumerable<TestCaseData> GCDArrayOfNumbersCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 750, 250, 2500, 1750 }).Returns(250);
                yield return new TestCaseData(new int[] { 2, 4, 6, 8 }).Returns(2);
                yield return new TestCaseData(new int[] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue }).Returns(int.MaxValue);
                yield return new TestCaseData(new int[] { 1, 5 }).Returns(1);
                yield return new TestCaseData(new int[] { 0, 0, 0, 0, 1 }).Returns(1);
                yield return new TestCaseData(new int[] { 0, 1, 0 }).Returns(1);
            }
        }

        #endregion

        #region Euclidian GCD tests

        [Test, TestCaseSource(nameof(GCDTwoNumbersCases))]
        public int EuclidianGCD_TwoNumbersPassed_ReturnResult(int a, int b)
        {
            return GCDAlgorithms.GetEuclidieanGcd(a, b);
        }

        [Test]
        public void EuclidianGCD_TwoNumbersAreIntMinValue_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GCDAlgorithms.GetEuclidieanGcd(int.MinValue, int.MinValue));

        [Test]
        public void EuclidianGCD_TwoNumbersAreZeros_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetEuclidieanGcd(0, 0));

        [Test, TestCaseSource(nameof(GCDThreeNumbersCases))]
        public int EuclidianGCD_ThreeNumbers_ReturnResult(int a, int b, int c)
        {
            return GCDAlgorithms.GetEuclidieanGcd(a, b, c);
        }

        [Test]
        public void EuclidianGCD_ThreeNumbersAreZeros_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetEuclidieanGcd(0, 0, 0));

        [Test]
        public void EuclidianGCD_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => GCDAlgorithms.GetEuclidieanGcd(null));

        [Test]
        public void EuclidianGCD_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetEuclidieanGcd(new int[] { }));

        [Test]
        public void EuclidianGCD_ArrayHasOneElement_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetEuclidieanGcd(new int[] { 12 }));

        [Test, TestCaseSource(nameof(GCDArrayOfNumbersCases))]
        public int EuclidianGCD_ConreteArrayOfNumbers_ReturnResult(int[] numbers)
        {
            return GCDAlgorithms.GetEuclidieanGcd(numbers);
        }

        #endregion

        #region Stein GCD tests

        [Test]
        public void SteinGCD_TwoNumbersAreZeros_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetSteinGcd(0, 0));

        public void SteinGCD_TwoNumbersAreIntMinValue_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetSteinGcd(int.MinValue, int.MinValue));

        [Test, TestCaseSource(nameof(GCDTwoNumbersCases))]
        public int SteinGCD_TwoNumbersPassed_ReturnResult(int a, int b)
        {
            int result = GCDAlgorithms.GetSteinGcd(out _, a, b);
            return result;
        }

        [Test]
        public void SteinGCD_ThreeNumbersAreZeros_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetSteinGcd(0, 0, 0));

        [Test, TestCaseSource(nameof(GCDThreeNumbersCases))]
        public int SteinGCD_ThreeNumbers_ReturnResult(int a, int b, int c)
        {
            return GCDAlgorithms.GetSteinGcd(out _, a, b, c);
        }

        [Test]
        public void SteinGCD_ArrayIsNull_ThrowArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => GCDAlgorithms.GetSteinGcd(null));

        [Test]
        public void SteinGCD_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetSteinGcd(new int[] { }));

        [Test]
        public void SteinGCD_ArrayHasOneElement_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GetSteinGcd(new int[] { 12 }));

        [Test, TestCaseSource(nameof(GCDArrayOfNumbersCases))]
        public int SteinGCD_ConreteArrayOfNumbers_ReturnResult(int[] numbers)
        {
            return GCDAlgorithms.GetSteinGcd(out _, numbers);
        }

        #endregion

        #endregion
    }
}
