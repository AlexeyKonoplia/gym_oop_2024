using GymOop2024.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace gym_oop_2024.Infrastructure.Persistence.Models;

public class UserSubscriptionModel
{
    [Key] 
    public Guid? UserSubscriptionId { get; set; }
    public Guid? Subscription { get; set; }
    public Guid? User { get; set; } 
    public bool? IsActive { get; set; }
    public bool? IsMulticard { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}