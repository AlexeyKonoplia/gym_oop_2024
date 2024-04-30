//using Itmo.Dev.Platform.Postgres.Extensions;
//using Itmo.Dev.Platform.Postgres.Plugins;
using gym_oop_2024.Application.Abstractions.Persistence;
using gym_oop_2024.Application.Abstractions.Repositories;
//using gym_oop_2024.Infrastructure.Persistence.Migrations;
//using gym_oop_2024.Infrastructure.Persistence.Plugins;
using gym_oop_2024.Infrastructure.Persistence.Repositories;
using gym_oop_2024.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gym_oop_2024.Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        //collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        //collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        //collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        //collection.AddHostedService<MigrationRunnerService>();
        //collection.AddScoped<IPersistenceContext, PersistenceContext>();
        
        
        AddContext(collection, configuration);
        collection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        // collection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        // добавить такие строки для каждой "сущности"
        return collection;
    }

    public static IServiceCollection AddContext(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
        return collection;
    }
}