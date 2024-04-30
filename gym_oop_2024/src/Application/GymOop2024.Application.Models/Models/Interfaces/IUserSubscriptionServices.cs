using GymOop2024.Application.Models.Models.Entities;

namespace GymOop2024.Application.Models.Models.Interfaces;

public interface IUserSubscriptionServices
{
    UserSubscription GetUserSubscriptionByUserId(Guid userId);

    UserSubscription AddUserSubscription(UserSubscription userSubscription);

    void UpdateUserSubscription(Guid id, UserSubscription userSubscription);

    void DeleteUserSubscription(UserSubscription userSubscriptionId);
}