using Maritime.Repository.Model;
using System.Collections.Generic;

namespace Maritime.Repository.Repository.Interface
{
    public interface IBatchRandomNumberRepository
    {
        void Save(IEnumerable<RandomNumber> randomNumbers);
    }
}