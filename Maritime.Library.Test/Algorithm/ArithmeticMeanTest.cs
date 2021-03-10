using Maritime.Library.Algorithm;
using NUnit.Framework;

namespace Maritime.Library.Test.Algorithm
{
    public class ArithmeticMeanTest
    {
        private ArithmeticMean unitUnderTest;

        [SetUp]
        public void Setup()
        {
            unitUnderTest = new ArithmeticMean();
        }

        [TestCase(new[] { 1d, 2d, 3d }, ExpectedResult = 6d / 3)]
        [TestCase(new[] { 1d, 2d, 3d }, ExpectedResult = 6d / 3)]
        [TestCase(new[] { 1d, 2d, 4d }, ExpectedResult = 7d / 3)]
        [TestCase(new[] { -1d, -2d, -3d }, ExpectedResult = -6d / 3)]
        [TestCase(new[] { 1.5d, 2.5d, 3.5d }, ExpectedResult = 7.5d / 3)]
        [TestCase(new[] { -1.5d, 2.5d, -3.0d }, ExpectedResult = -2d / 3)]
        public double Calculate_TestCases_ShouldCalculateCorrectly(double[] numbers)
        {
            return unitUnderTest.Calculate(numbers);
        }

        [TestCase(new double[0], ExpectedResult = 0)]
        public double Calculate_EmptyList_ShouldReturnZero(double[] numbers)
        {
            return unitUnderTest.Calculate(numbers);
        }
    }
}
