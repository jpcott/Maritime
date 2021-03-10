using Maritime.Library.Algorithm.Interface;
using System;
using System.Collections.Generic;

namespace Maritime.Library.Algorithm
{
    public class FrequencyDistribution : IFrequencyDistribution
    {
        private readonly uint bandingIncrement;

        public FrequencyDistribution(uint bandingIncrement)
        {
            if (bandingIncrement == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bandingIncrement), $"Cannot have a banding of size {bandingIncrement}.");
            }
            this.bandingIncrement = bandingIncrement;
        }

        public IDictionary<Tuple<double, double>, int> Calculate(IList<double> numbers)
        {
            var numberDistribution = new Dictionary<Tuple<double, double>, int>();
            foreach (var number in numbers)
            {
                var banding = CalculateBanding(number);
                if (!numberDistribution.ContainsKey(banding))
                {
                    numberDistribution.Add(banding, 1);
                }
                else
                {
                    numberDistribution[banding]++;
                }
            }
            return numberDistribution;
        }

        private Tuple<double, double> CalculateBanding(double number)
        {
            var lowerBand = Math.Floor(number / bandingIncrement) * bandingIncrement;
            var uppderBand = lowerBand  + bandingIncrement;
            return new Tuple<double, double>(lowerBand, uppderBand);
        }
    }
}
