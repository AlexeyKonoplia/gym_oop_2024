namespace GymOop2024.Application.Models.Models.Entities;

public class User
{
    public Guid? UserId { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}