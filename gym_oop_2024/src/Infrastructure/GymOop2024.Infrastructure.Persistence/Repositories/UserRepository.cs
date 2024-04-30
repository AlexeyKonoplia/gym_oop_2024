using GymOop2024.Application.Abstractions.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using GymOop2024.Application.Models.Models.Interfaces;
using System.Linq;
using System.Xml.Linq;
using GymOop2024.Application.Models;
using GymOop2024.Application.Models.Models.Entities;
using GymOop2024.Infrastructure.Persistence.Contexts;
using GymOop2024.Infrastructure.Persistence.Models;


namespace GymOop2024.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User, UserModel>, IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public User GetUserById(Guid userId)
    {
        var userModel = _context.Users.FirstOrDefault(u => u.UserId == userId);

        if (userModel == null)
        {
            throw new Exception();
        }

        return new User
        {
            UserId = userModel.UserId,
            Name = userModel.Name,
            LastName = userModel.LastName,
            Surname = userModel.Surname,
            Email = userModel.Email,
            Phone = userModel.Phone,
        };
    }

    public override User Add(User entity)
    {
        UserModel model = MapFrom(entity);

        _context.Users.Add(model);

        _context.SaveChanges();

        return entity;
    }
    
    public void DeleteUser(Guid userId)
    {
        var userExists = _context.Users.FirstOrDefault(s => s.UserId == userId);
        if (userExists == null)
        {
            throw new Exception("User not found");
        }

        _context.Users.Remove(userExists);

        _context.SaveChanges();
    }

    protected override DbSet<UserModel> DbSet => _context.Users;

    protected override UserModel MapFrom(User entity)
    {
        return new UserModel
        {
            UserId = entity.UserId,
            Name = entity.Name,
            LastName = entity.LastName,
            Surname = entity.Surname,
            Email = entity.Email,
            Phone = entity.Phone,
        };
    }

    protected override bool Equal(User entity, UserModel model)
    {
        return entity.UserId.Equals(model.UserId);
    }

    protected override void UpdateModel(UserModel model, User entity)
    {
        model.UserId = entity.UserId;
        model.Name = entity.Name;
        model.LastName = entity.LastName;
        model.Surname = entity.Surname;
        model.Email = entity.Email;
        model.Phone = entity.Phone;
    }

    public void UpdateUser(Guid id, User user)
    {
        var userExists = _context.Users.FirstOrDefault(s => s.UserId == id);

        if (userExists == null)
        {
            throw new Exception("User not found");
        }

        // Обновляем свойства существующего пользователя
        userExists.UserId = user.UserId;
        userExists.Name = user.Name;
        userExists.LastName = user.LastName;
        userExists.Surname = user.Surname;
        userExists.Email = user.Email;
        userExists.Phone = user.Phone;

        _context.SaveChanges();
    }

    public User GetUserByPhone(string phone)
    {
        var userModel = _context.Users.FirstOrDefault(u => u.Phone == phone);

        if (userModel is null)
        {
            throw new Exception();
        }
        
        return new User
        {
            UserId = userModel.UserId,
            Name = userModel.Name,
            LastName = userModel.LastName,
            Surname = userModel.Surname,
            Email = userModel.Email,
            Phone = userModel.Phone,
        };
    }

    public IEnumerable<User> GetAllUsers()
    {
        var users = _context.Users
            .Select(userModel => new User
            {
                UserId = userModel.UserId,
                Name = userModel.Name,
                LastName = userModel.LastName,
                Surname = userModel.Surname,
                Email = userModel.Email,
                Phone = userModel.Phone,
            })
            .ToArray();

        return users;
    }

}