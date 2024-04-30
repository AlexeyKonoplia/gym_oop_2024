using GymOop2024.Application.Models.Models.Entities;

namespace GymOop2024.Application.Abstractions.Persistence.Repositories;

public interface IUserRepository
{
    User GetUserById(Guid userId);

    User GetUserByPhone(string phone);

    IEnumerable<User> GetAllUsers();

    User Add(User user);

    void UpdateUser(Guid id, User user);

    void DeleteUser(Guid userId);
}