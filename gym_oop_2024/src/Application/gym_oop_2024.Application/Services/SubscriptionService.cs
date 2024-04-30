using gym_oop_2024.Application.Abstractions.Repositories;
using gym_oop_2024.Application.Models;
using gym_oop_2024.Application.Models.Models.Interfaces;

namespace gym_oop_2024.Application.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public Subscription GetById(Guid subscriptionId)
    {
        return _subscriptionRepository.GetById(subscriptionId);
    }

    public IEnumerable<Subscription> GetAllSubscriptions()
    {
        return _subscriptionRepository.GetAllSubscriptions();
    }

    public IEnumerable<Subscription> GetSubscriptionsByGymId(Guid gymId)
    {
        return _subscriptionRepository.GetSubscriptionsByGymId(gymId);
    }

    public Subscription Add(Subscription subscription)
    {
        _subscriptionRepository.Add(subscription);
        return subscription;
    }

    public void Update(Guid id, Subscription subscription)
    {
        _subscriptionRepository.Update(id, subscription);
    }

    public void Remove(Guid subscriptionId)
    {
        _subscriptionRepository.Remove(subscriptionId);
    }
}