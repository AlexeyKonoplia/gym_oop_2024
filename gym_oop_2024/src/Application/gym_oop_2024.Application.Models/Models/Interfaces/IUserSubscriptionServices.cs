namespace gym_oop_2024.Application.Models.Models.Interfaces;

public interface IUserSubscriptionServices
{
    IEnumerable<UserSubscription> GetUserSubscriptionsByUserId(int userId);
    IEnumerable<UserSubscription> GetActiveUserSubscriptionsByUserId(int userId);
    void AddUserSubscription(UserSubscription userSubscription);
    void UpdateUserSubscription(UserSubscription userSubscription);
    void DeleteUserSubscription(int userSubscriptionId);
}