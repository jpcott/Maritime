using Maritime.Library.Algorithm;
using NUnit.Framework;
using System;

namespace Maritime.Library.Test.Algorithm
{
    public class StandardDeviationTest
    {

        [Test]
        public void Calculate_RandomSample_ShouldCalculateStandDeviation()
        {
            // I'd usually mock this but in the interest of time just do an integration test.
            var unitUnderTest = new StandardDeviation(new ArithmeticMean());

            var numbers = new[] { 4d, 9d, 11d, 12d, 17d, 5d, 8d, 12d, 14d };

            var result = unitUnderTest.Calculate(numbers);

            // irrational number round to nearest 2dp.
            Assert.AreEqual(3.94, Math.Round(result, 2));
        }
    }
}
