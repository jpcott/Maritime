using Maritime.Library.Algorithm;
using Maritime.Library.Algorithm.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Maritime.Web.DepedencyInjection
{
    public class Algorithm
    {
        public static IServiceCollection Install(IServiceCollection services)
        {
            services.AddSingleton<IStandardDeviation, StandardDeviation>();
            services.AddSingleton<IArithmeticMean, ArithmeticMean>();
            services.AddSingleton<IFrequencyDistribution>(new FrequencyDistribution(10));

            return services;
        }
    }
}
