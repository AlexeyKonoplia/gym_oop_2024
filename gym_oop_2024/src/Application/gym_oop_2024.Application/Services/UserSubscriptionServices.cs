using gym_oop_2024.Application.Models;
using gym_oop_2024.Application.Models.Models.Interfaces;

namespace gym_oop_2024.Application.Services;

public class UserSubscriptionServices : IUserSubscriptionServices
{
    public IEnumerable<UserSubscription> GetUserSubscriptionsByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserSubscription> GetActiveUserSubscriptionsByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public void AddUserSubscription(UserSubscription userSubscription)
    {
        throw new NotImplementedException();
    }

    public void UpdateUserSubscription(UserSubscription userSubscription)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserSubscription(int userSubscriptionId)
    {
        throw new NotImplementedException();
    }
}