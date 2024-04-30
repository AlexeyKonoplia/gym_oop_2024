namespace GymOop2024.Application.Models.Models.Entities;

public class Subscription
{
    public Guid? SubscriptionId { get; set; }

    public Guid? GymId { get; set; } // foreign

    public string? SubscriptionName { get; set; }

    public double? SubscriptionPrice { get; set; }

    public string? SubscriptionDescription { get; set; }

    public int? DefaultDurationInMonths { get; set; }
}