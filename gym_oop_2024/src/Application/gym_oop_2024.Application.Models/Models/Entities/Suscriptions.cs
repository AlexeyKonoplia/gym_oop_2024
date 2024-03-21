namespace gym_oop_2024.Application.Models;

public class Suscription
{
    public int SubscriptionId;
    public string GymId; // foreign
    public string SubscriptionName;
    public double SubscriptionPrice;
    public string SubscriptionDescription;
    public int DefaultDurationInMonths;
}