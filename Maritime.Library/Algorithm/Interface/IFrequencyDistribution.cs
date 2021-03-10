using System;
using System.Collections.Generic;

namespace Maritime.Library.Algorithm.Interface
{
    public interface IFrequencyDistribution
    {
        IDictionary<Tuple<double, double>, int> Calculate(IList<double> numbers);
    }
}