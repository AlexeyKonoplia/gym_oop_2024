using gym_oop_2024.Application.Models;

namespace gym_oop_2024.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User GetUserById(Guid userId);
    User GetUserByPhone(string Phone);
    IEnumerable<User> GetAllUsers();
    User Add(User user);
    void UpdateUser(Guid id, User user);
    void DeleteUser(Guid userId);
}