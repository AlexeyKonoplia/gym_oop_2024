using GymOop2024.Application.Models.Models.Entities;

namespace GymOop2024.Application.Abstractions.Persistence.Repositories;

public interface IUserSubscriptionRepository
{
    UserSubscription GetUserSubscriptionsByUserId(Guid userId);
    UserSubscription GetActiveUserSubscriptionsByUserId(Guid userId);
    IEnumerable<UserSubscription> GetAllUserSubscriptions();
    UserSubscription Add(UserSubscription userSubscription);
    UserSubscription Update(Guid userSubId, UserSubscription userSubscription);
    void Remove(Guid userSubscriptionId);
}