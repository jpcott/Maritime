using Maritime.Repository.Model;
using System.Collections.Generic;

namespace Maritime.Repository.Repository.Interface
{
    public interface IRandomNumberRepository
    {
        IEnumerable<RandomNumber> GetAll();
    }
}