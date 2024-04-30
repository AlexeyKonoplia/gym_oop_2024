using gym_oop_2024.Infrastructure.Persistence.Repositories;
using GymOop2024.Application.Models;
using GymOop2024.Application.Models.Models.Entities;
using GymOop2024.Application.Models.Models.Interfaces;
using GymOop2024.Infrastructure.Persistence.Repositories;

namespace GymOop2024.Application.Services;

public class UserSubscriptionServices : IUserSubscriptionServices
{
    private readonly UserSubscriptionRepository _userSubscriptionRepository;

    public UserSubscriptionServices(UserSubscriptionRepository userSubscriptionRepository)
    {
        _userSubscriptionRepository = userSubscriptionRepository;
    }

    public UserSubscription AddUserSubscription(UserSubscription userSubscription)
    {
        _userSubscriptionRepository.AddUserSubscription(userSubscription);

        return userSubscription;
    }

    public void UpdateUserSubscription(Guid userSubId, UserSubscription userSubscription)
    {
        _userSubscriptionRepository.Update(userSubId, userSubscription);
    }

    public void DeleteUserSubscription(UserSubscription userSubscriptionId)
    {
        _userSubscriptionRepository.Remove(userSubscriptionId);
    }

    public UserSubscription GetUserSubscriptionByUserId(Guid userSubId)
    {
        return _userSubscriptionRepository.GetUserSubscriptionByUserId(userSubId);
    }

    public IEnumerable<UserSubscription> GetAllUserSubscriptions()
    {
        return _userSubscriptionRepository.GetAllUserSubscriptions();
    }
}