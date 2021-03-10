using Maritime.Library.Algorithm;
using NUnit.Framework;
using System;

namespace Maritime.Library.Test.Algorithm
{
    public class FrequencyDistributionTest
    {
        [Test]
        public void Constructor_Zero_ThrowArugmentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FrequencyDistribution(0));
        }

        [Test]
        public void Calculate_HighDecimal_ShouldNotRoundUp()
        {
            var numbers = new[] { 9.9d };
            var unitUnderTest = new FrequencyDistribution(10);

            var distribution = unitUnderTest.Calculate(numbers);

            Assert.AreEqual(1, distribution[new Tuple<double, double>(0d, 10d)]);
        }

        [Test]
        public void Calculate_OnBondary_ShouldApportionCorrectly()
        {
            var numbers = new[] { 9d, 10d };
            var unitUnderTest = new FrequencyDistribution(10);

            var distribution = unitUnderTest.Calculate(numbers);

            Assert.AreEqual(1, distribution[new Tuple<double, double>(0d, 10d)]);
            Assert.AreEqual(1, distribution[new Tuple<double, double>(10d, 20d)]);
        }

        [Test]
        public void Calculate_MinusNumbers_ShouldApportionCorrectly()
        {
            var numbers = new[] { -10d };
            var unitUnderTest = new FrequencyDistribution(10);

            var distribution = unitUnderTest.Calculate(numbers);

            Assert.AreEqual(1, distribution[new Tuple<double, double>(-10d, 0d)]);
        }

        [Test]
        public void Calculate_MultipleOccurences_ShouldApportionCorrectly()
        {
            var numbers = new[] { 9.9, 0, 1 };
            var unitUnderTest = new FrequencyDistribution(10);

            var distribution = unitUnderTest.Calculate(numbers);

            Assert.AreEqual(3, distribution[new Tuple<double, double>(0d, 10d)]);
        }

        [Test]
        public void Calculate_BandingOfTwo_ShouldApportionCorrectly()
        {
            var numbers = new[] { -1d, 0d, 1d, 2d, 3d };
            var unitUnderTest = new FrequencyDistribution(2);

            var distribution = unitUnderTest.Calculate(numbers);

            Assert.AreEqual(1, distribution[new Tuple<double, double>(-2d, 0d)]);
            Assert.AreEqual(2, distribution[new Tuple<double, double>(0d, 2d)]);
            Assert.AreEqual(2, distribution[new Tuple<double, double>(2d, 4d)]);
        }

        [Test]
        public void Calculate_Any_ShouldNotCreateEmptyGroups()
        {
            var numbers = new[] { 10d };
            var unitUnderTest = new FrequencyDistribution(10);

            var distribution = unitUnderTest.Calculate(numbers);

            Assert.AreEqual(1, distribution.Keys.Count);
        }
    }
}
