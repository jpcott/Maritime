using Maritime.Repository.Model;
using Maritime.Repository.Repository.Interface;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;

namespace Maritime.Repository.Repository
{
    public class BatchRandomNumberRepository : IBatchRandomNumberRepository
    {
        private readonly IStatelessSession session;
        private readonly uint batchSize;

        public BatchRandomNumberRepository(IStatelessSession session, uint batchSize)
        {
            if (batchSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(batchSize), "Batch Size must be a greater than zero.");
            }
            if (batchSize > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(batchSize), $"Batch Size of {batchSize} exceeed max size.");
            }

            this.session = session;
            this.batchSize = batchSize;
        }

        public void Save(IEnumerable<RandomNumber> randomNumbers)
        {
            using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                session.SetBatchSize((int)batchSize);
                foreach (var entity in randomNumbers)
                {
                    session.Insert(entity);
                }
                transaction.Commit();
            }
        }
    }
}
