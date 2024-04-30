using gym_oop_2024.Application.Abstractions.Repositories;
using gym_oop_2024.Infrastructure.Persistence.Repositories;
using gym_oop_2024.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace gym_oop_2024.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        return collection;
    }
}