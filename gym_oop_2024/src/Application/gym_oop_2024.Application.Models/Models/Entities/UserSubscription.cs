namespace gym_oop_2024.Application.Models;

public class UserSubscription
{
    public int UserSubscriptionId;
    public int SubscriptionId; // foreign
    public int UserId; // foreign
    public bool IsActive;
    public bool IsMulticard;
    public DateTime StartDate;
    public DateTime EndDate;
}