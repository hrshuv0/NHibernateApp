﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using InventoryDAO.EntityMapper;

namespace InventoryApp.Data;

public static class NHibernateExtension
{
    public static IServiceCollection InitiateNHibernate(this IServiceCollection services, string connectionString)
    {
        var sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
            .Mappings(m =>
            {
                m.FluentMappings.AddFromAssemblyOf<ProductMap>();
            }).BuildSessionFactory();

        services.AddSingleton(sessionFactory);
        services.AddScoped(factory => sessionFactory.OpenSession());

        


        return services;
    }
}