using System.ComponentModel.DataAnnotations;

namespace gym_oop_2024.Infrastructure.Persistence.Models;

public class UserModel
{
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}