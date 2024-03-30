namespace a;

public interface ISubscriptionRepository
{
    Subscription GetSubscriptionById(int subscriptionId);
    IEnumerable<Subscription> GetAllSubscriptions();
    IEnumerable<Subscription> GetSubscriptionsByGymId(int gymId);
    void AddSubscription(Subscription subscription);
    void UpdateSubscription(Subscription subscription);
    void DeleteSubscription(int subscriptionId);
}