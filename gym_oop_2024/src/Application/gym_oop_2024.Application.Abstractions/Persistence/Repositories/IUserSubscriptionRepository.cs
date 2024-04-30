using gym_oop_2024.Application.Models;

namespace gym_oop_2024.Application.Abstractions.Repositories;

public interface IUserSubscriptionRepository
{
    IEnumerable<UserSubscription> GetUserSubscriptionsByUserId(int userId);
    IEnumerable<UserSubscription> GetActiveUserSubscriptionsByUserId(int userId);
    void AddUserSubscription(UserSubscription userSubscription);
    void UpdateUserSubscription(UserSubscription userSubscription);
    void DeleteUserSubscription(int userSubscriptionId);
}