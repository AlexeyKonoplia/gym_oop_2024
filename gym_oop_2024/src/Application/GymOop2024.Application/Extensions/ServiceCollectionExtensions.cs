using GymOop2024.Application.Abstractions.Persistence.Repositories;
using GymOop2024.Application.Services;
using GymOop2024.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GymOop2024.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        return collection;
    }
}