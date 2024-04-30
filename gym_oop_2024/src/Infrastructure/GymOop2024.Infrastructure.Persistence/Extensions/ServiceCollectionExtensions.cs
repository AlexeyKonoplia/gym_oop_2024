using GymOop2024.Application.Abstractions.Persistence.Repositories;
using GymOop2024.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymOop2024.Infrastructure.Persistence.Extensions;

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
        collection.AddDbContext<DbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
        return collection;
    }

    public static void AddInfrastructurePersistence(this IServiceCollection collection)
    {
        throw new NotImplementedException();
    }
}