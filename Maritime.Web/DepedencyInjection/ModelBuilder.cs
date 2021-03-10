using Maritime.Web.ModelBuilders;
using Maritime.Web.ModelBuilders.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Maritime.Web.DepedencyInjection
{
    public class ModelBuilder
    {
        public static IServiceCollection Install(IServiceCollection services)
        {
            services.AddTransient<IIndexModelBuilder, IndexModelBuilder>();

            return services;
        }
    }
}
