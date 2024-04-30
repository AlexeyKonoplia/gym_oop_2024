namespace gym_oop_2024.Application.Models.Models.Interfaces;

public interface IUserService
{
    User GetUserById(int userId);
    User GetUserByPhone(string Phone);
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}