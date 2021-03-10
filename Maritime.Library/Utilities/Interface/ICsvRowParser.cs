using System.Collections.Generic;

namespace Maritime.Library.Utilities.Interface
{
    public interface ICsvRowParser
    {
        IEnumerable<double> ParseAsDouble(string row);
    }
}