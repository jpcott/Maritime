using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Microsoft.Extensions.Configuration;
using NHibernate.Cfg;
using Maritime.Repository.Model;
using Maritime.Repository.Repository;
using Maritime.Repository.Repository.Interface;

namespace Maritime.Web.DepedencyInjection
{
    public class Nhibernate
    {
        public static IServiceCollection Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(SetupConfiguration(configuration));
            services.AddSingleton(provider => provider.GetService<Configuration>().BuildSessionFactory());
            services.AddTransient(provider => provider.GetService<ISessionFactory>().OpenSession());
            services.AddTransient(provider => provider.GetService<ISessionFactory>().OpenStatelessSession());

            services.AddTransient<IBatchRandomNumberRepository>(
                provider => new BatchRandomNumberRepository(provider.GetService<IStatelessSession>(), 500));
            services.AddTransient<IRandomNumberRepository, RandomNumberRepository>();

            return services;
        }

        private static Configuration SetupConfiguration(IConfiguration configuration)
        {
            var fluentConfiguration = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(configuration.GetConnectionString("Maritime")))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RandomNumber>())
            .BuildConfiguration();

            return fluentConfiguration;
        }
    }
}
