using System.Collections.Generic;

namespace Maritime.Library.Algorithm.Interface
{
    public interface IStandardDeviation
    {
        public double Calculate(IList<double> numbers);
    }
}
