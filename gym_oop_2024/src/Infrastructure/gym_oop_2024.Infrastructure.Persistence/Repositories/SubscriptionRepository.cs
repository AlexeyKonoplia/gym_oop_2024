using gym_oop_2024.Application.Models;
using gym_oop_2024.Infrastructure.Persistence.Models;
using gym_oop_2024.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using gym_oop_2024.Application.Abstractions.Repositories;
using gym_oop_2024.Application.Models.Models.Interfaces;


namespace gym_oop_2024.Infrastructure.Persistence.Repositories;

public class SubscriptionRepository : BaseRepository<Subscription, SubscriptionModel>, ISubscriptionRepository
{
    private readonly DatabaseContext _context;

    public SubscriptionRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
    
    public Subscription GetById(Guid id)
    {
        var subscriptionModel = _context.Subscriptions.FirstOrDefault(s => s.SubscriptionId == id);

        if (subscriptionModel == null)
        {
            throw new Exception();
        }

        return new Subscription
        {
            SubscriptionId = subscriptionModel.SubscriptionId,
            GymId = subscriptionModel.GymId,
            SubscriptionName = subscriptionModel.SubscriptionName,
            SubscriptionPrice = subscriptionModel.SubscriptionPrice,
            SubscriptionDescription = subscriptionModel.SubscriptionDescription,
            DefaultDurationInMonths = subscriptionModel.DefaultDurationInMonths,
        };
    }
    
    public override Subscription Add(Subscription entity)
    {
        SubscriptionModel model = MapFrom(entity);

        _context.Subscriptions.Add(model);

        _context.SaveChanges();

        return entity;
    }
    
    public void Remove(Guid id)
    {
        var subscriptionExists = _context.Subscriptions.FirstOrDefault(s => s.SubscriptionId == id);
        if (subscriptionExists == null)
        {
            throw new Exception("Subscription not found");
        }

        _context.Subscriptions.Remove(subscriptionExists);

        _context.SaveChanges();
    }
    protected override DbSet<SubscriptionModel> DbSet => _context.Subscriptions;
    
    protected override SubscriptionModel MapFrom(Subscription entity)
    {
        return new SubscriptionModel
        {
            SubscriptionId = entity.SubscriptionId,
            GymId = entity.GymId,
            SubscriptionName = entity.SubscriptionName,
            SubscriptionPrice = entity.SubscriptionPrice,
            SubscriptionDescription = entity.SubscriptionDescription,
            DefaultDurationInMonths = entity.DefaultDurationInMonths,
        };
    }
    
    protected override bool Equal(Subscription entity, SubscriptionModel model)
    {
        return entity.SubscriptionId.Equals(model.SubscriptionId);
    }

    protected override void UpdateModel(SubscriptionModel model, Subscription entity)
    {
        model.SubscriptionId = entity.SubscriptionId;
        model.GymId = entity.GymId;
        model.SubscriptionName = entity.SubscriptionName;
        model.SubscriptionPrice = entity.SubscriptionPrice;
        model.SubscriptionDescription = entity.SubscriptionDescription;
        model.DefaultDurationInMonths = entity.DefaultDurationInMonths;
    }

    public void Update(Guid id, Subscription subscription)
    {
        var existingSubscription = _context.Subscriptions.Find(id);

        if (existingSubscription == null)
        {
            throw new Exception("Subscritpion not found");
        }

        // Обновляем свойства существующего пользователя
        existingSubscription.SubscriptionId = existingSubscription.SubscriptionId;
        existingSubscription.GymId = existingSubscription.GymId;
        existingSubscription.SubscriptionName = existingSubscription.SubscriptionName;
        existingSubscription.SubscriptionPrice = existingSubscription.SubscriptionPrice;
        existingSubscription.SubscriptionDescription = existingSubscription.SubscriptionDescription;
        existingSubscription.DefaultDurationInMonths = existingSubscription.DefaultDurationInMonths;

        _context.SaveChanges();
    }
    

    public IEnumerable<Subscription> GetSubscriptionsByGymId(Guid gymId)
    {
        var subscriptions = _context.Subscriptions
            .Where(s => s.GymId == gymId)
            .Select(subscriptionModel => new Subscription
            {
                SubscriptionId = subscriptionModel.SubscriptionId,
                GymId = subscriptionModel.GymId,
                SubscriptionName = subscriptionModel.SubscriptionName,
                SubscriptionPrice = subscriptionModel.SubscriptionPrice,
                SubscriptionDescription = subscriptionModel.SubscriptionDescription,
                DefaultDurationInMonths = subscriptionModel.DefaultDurationInMonths
            })
            .ToArray();

        return subscriptions;
    }
    
    public IEnumerable<Subscription> GetAllSubscriptions()
    {
        var subscriptions = _context.Subscriptions
            .Select(subscriptionModel => new Subscription
            {
                SubscriptionId = subscriptionModel.SubscriptionId,
                GymId = subscriptionModel.GymId,
                SubscriptionName = subscriptionModel.SubscriptionName,
                SubscriptionPrice = subscriptionModel.SubscriptionPrice,
                SubscriptionDescription = subscriptionModel.SubscriptionDescription,
                DefaultDurationInMonths = subscriptionModel.DefaultDurationInMonths
            })
            .ToArray();

        return subscriptions;
    }

}