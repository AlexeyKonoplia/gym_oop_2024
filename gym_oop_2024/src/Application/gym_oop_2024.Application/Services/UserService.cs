using gym_oop_2024.Application.Abstractions.Repositories;
using gym_oop_2024.Application.Models;
using gym_oop_2024.Application.Models.Models.Interfaces;

namespace gym_oop_2024.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUserById(Guid userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public User GetUserByPhone(string phone)
    {
        return _userRepository.GetUserByPhone(phone);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public User Add(User user)
    {
        _userRepository.Add(user);
        return user;
    }

    public void UpdateUser(Guid id, User user)
    {
        _userRepository.UpdateUser(id, user);
    }

    public void DeleteUser(Guid userId)
    {
        _userRepository.DeleteUser(userId);
    }
}