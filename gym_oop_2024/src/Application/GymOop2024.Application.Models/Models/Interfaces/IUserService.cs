using GymOop2024.Application.Models.Models.Entities;

namespace GymOop2024.Application.Models.Models.Interfaces;

public interface IUserService
{
    User GetUserById(Guid userId);

    User GetUserByPhone(string phone);

    IEnumerable<User> GetAllUsers();

    User Add(User user);

    void UpdateUser(Guid id, User user);

    void DeleteUser(Guid userId);
}