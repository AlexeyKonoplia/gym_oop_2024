namespace gym_oop_2024.Application.Models;

public class UserSubscription
{
    public int? UserSubscriptionId { get; set; };
    public Subscription? Subscription { get; set; }; // foreign
    public User? User { get; set; }; // foreign
    public bool? IsActive { get; set; };
    public bool? IsMulticard { get; set; };
    public DateTime StartDate { get; set; };
    public DateTime EndDate { get; set; };
}