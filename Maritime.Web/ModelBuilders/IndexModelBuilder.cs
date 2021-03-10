using Maritime.Library.Algorithm.Interface;
using Maritime.Repository.Repository.Interface;
using Maritime.Web.ModelBuilders.Interface;
using Maritime.Web.Models;
using System.Linq;

namespace Maritime.Web.ModelBuilders
{
    public class IndexModelBuilder : IIndexModelBuilder
    {
        private readonly IRandomNumberRepository randomNumberRepository;
        private readonly IFrequencyDistribution frequencyDistribution;
        private readonly IArithmeticMean arithmeticMean;
        private readonly IStandardDeviation standardDeviation;

        public IndexModelBuilder(IRandomNumberRepository randomNumberRepository, IFrequencyDistribution frequencyDistribution,
            IArithmeticMean arithmeticMean, IStandardDeviation standardDeviation)
        {
            this.randomNumberRepository = randomNumberRepository;
            this.frequencyDistribution = frequencyDistribution;
            this.arithmeticMean = arithmeticMean;
            this.standardDeviation = standardDeviation;
        }

        public IndexViewModel Build()
        {
            var randomNumbers = randomNumberRepository.GetAll().Select(rn => rn.Number).ToList();
            return new IndexViewModel()
            {
                FrequencyDistribution = frequencyDistribution.Calculate(randomNumbers),
                Mean = arithmeticMean.Calculate(randomNumbers),
                StandardDeviation = standardDeviation.Calculate(randomNumbers)
            };
        }
    }
}
