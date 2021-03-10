using Maritime.Library.Utilities.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Maritime.Library.Utilities
{
    public class CsvRowParser : ICsvRowParser
    {
        public IEnumerable<double> ParseAsDouble(string row)
        {
            return row.Split(',').Select(item => double.Parse(item.Trim()));
        }
    }
}
