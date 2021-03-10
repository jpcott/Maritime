using Maritime.Library.Algorithm.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Maritime.Library.Algorithm
{
    public class ArithmeticMean : IArithmeticMean
    {
        public double Calculate(IList<double> numbers)
        {
            if (numbers.Count() == 0)
            {
                return 0;
            }

            return numbers.Sum() / numbers.Count();
        }
    }
}
