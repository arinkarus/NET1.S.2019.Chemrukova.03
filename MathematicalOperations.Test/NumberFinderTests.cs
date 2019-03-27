using NUnit.Framework;
using System;

namespace MathematicalOperations.Test
{
    public class NumberFinderTests
    {
        [TestCase(int.MinValue)]
        [TestCase(-100)]
        [TestCase(0)]
        public void NextBiggerThan_NumberNotPositive_ThrowArgumentException(int number) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberFinder.NextBiggerThan(number));

        [TestCase(33333301, ExpectedResult = 33333310)]
        [TestCase(1, ExpectedResult = null)]
        [TestCase(534976, ExpectedResult = 536479)]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(124121133, ExpectedResult = 124121313)]
        [TestCase(int.MaxValue, ExpectedResult = null)]
        [TestCase(2000, ExpectedResult = null)]
        [TestCase(111111111, ExpectedResult = null)]
        public int? NextBiggerThan_ConcreteNumber_ReturnResult(int number)
        {
            return NumberFinder.NextBiggerThan(number);
        }
    }
}
