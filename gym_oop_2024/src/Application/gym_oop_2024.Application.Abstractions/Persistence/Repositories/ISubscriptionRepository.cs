using gym_oop_2024.Application.Models;

namespace gym_oop_2024.Application.Abstractions.Repositories;

public interface ISubscriptionRepository
{
    Subscription GetById(Guid subscriptionId);
    IEnumerable<Subscription> GetAllSubscriptions();
    IEnumerable<Subscription> GetSubscriptionsByGymId(Guid gymId);
    Subscription Add(Subscription subscription);
    void Update(Guid id, Subscription subscription);
    void Remove(Guid subscriptionId);
}