using Maritime.Library.Utilities;
using Maritime.Library.Utilities.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Maritime.Web.DepedencyInjection
{
    public class Utilties
    {
        public static IServiceCollection Install(IServiceCollection services)
        {
            services.AddSingleton<ICsvRowParser, CsvRowParser>();

            return services;
        }
    }
}
