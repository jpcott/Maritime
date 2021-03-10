using Maritime.Library.Algorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maritime.Library.Algorithm
{
    public class StandardDeviation : IStandardDeviation
    {
        private readonly IArithmeticMean arithmeticMeanAlgorithm;

        public StandardDeviation(IArithmeticMean arithmeticMean)
        {
            arithmeticMeanAlgorithm = arithmeticMean;
        }

        public double Calculate(IList<double> numbers)
        {
            var arithmeticMean = arithmeticMeanAlgorithm.Calculate(numbers);

            var differenceSquared = numbers.Select(n => Math.Pow(n - arithmeticMean, 2));
            var squaredMean = arithmeticMeanAlgorithm.Calculate(differenceSquared.ToList());

            return Math.Sqrt(squaredMean);
        }
    }
}
