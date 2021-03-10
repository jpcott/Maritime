using Maritime.Repository.Model;
using Maritime.Repository.Repository.Interface;
using NHibernate;
using System.Collections.Generic;

namespace Maritime.Repository.Repository
{
    public class RandomNumberRepository : IRandomNumberRepository
    {
        private readonly ISession session;

        public RandomNumberRepository(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<RandomNumber> GetAll()
        {
            return session.QueryOver<RandomNumber>().List();
        }
    }
}
