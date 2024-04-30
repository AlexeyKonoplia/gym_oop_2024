using System.ComponentModel.DataAnnotations;

namespace GymOop2024.Infrastructure.Persistence.Models;

public class GymModel
{
    [Key]
    public Guid? GymId { get; set; }

    public string? GymName { get; set; }

    public string? GymAddress { get; set; }
}