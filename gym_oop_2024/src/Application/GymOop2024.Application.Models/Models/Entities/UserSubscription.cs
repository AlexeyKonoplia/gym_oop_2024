namespace GymOop2024.Application.Models.Models.Entities;

public class UserSubscription
{
    public Guid? UserSubscriptionId { get; set; }

    public Guid? SubscriptionId { get; set; } // foreign

    public Guid? User { get; set; } // foreign

    public bool? IsActive { get; set; }

    public bool? IsMulticard { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}