using a;
using gym_oop_2024.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace gym_oop_2024.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        // TODO: add services
        collection.AddScoped<IGymRepository, GymRepository>();
        return collection;
    }
}