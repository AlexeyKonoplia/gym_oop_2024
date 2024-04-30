namespace gym_oop_2024.Application.Models.Models.Interfaces;

public interface ISubscriptionService
{
    Subscription GetById(Guid subscriptionId);
    IEnumerable<Subscription> GetAllSubscriptions();
    IEnumerable<Subscription> GetSubscriptionsByGymId(Guid gymId);
    Subscription Add(Subscription subscription);
    void Update(Guid id, Subscription subscription);
    void Remove(Guid subscriptionId);

}