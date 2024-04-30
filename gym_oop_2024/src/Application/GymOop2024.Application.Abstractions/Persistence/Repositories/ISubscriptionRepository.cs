using GymOop2024.Application.Models.Models.Entities;

namespace GymOop2024.Application.Abstractions.Persistence.Repositories;

public interface ISubscriptionRepository
{
    Subscription GetById(Guid subscriptionId);

    IEnumerable<Subscription> GetAllSubscriptions();

    IEnumerable<Subscription> GetSubscriptionsByGymId(Guid gymId);

    Subscription Add(Subscription subscription);

    void Update(Guid id, Subscription subscription);

    void Remove(Guid subscriptionId);
}