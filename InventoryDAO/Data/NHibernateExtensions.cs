using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using InventoryDAO.EntityMapper;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Repository;

namespace InventoryDAO.Data;

public static class NHibernateExtensions
{
    public static IServiceCollection InitiateNhibernate(this IServiceCollection services, string connectionString)
    {
        var sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
            .Mappings(m =>
            {
                m.FluentMappings.AddFromAssemblyOf<ProductMap>();
            })
            .BuildSessionFactory();

        services.AddSingleton(sessionFactory);
        services.AddScoped(factory => sessionFactory.OpenSession());

        services.AddScoped<IProductRepository, ProductRepository>();


        return services;
    }
}