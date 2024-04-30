using GymOop2024.Application.Models;
using GymOop2024.Infrastructure.Persistence.Contexts;
using gym_oop_2024.Infrastructure.Persistence.Models;
using GymOop2024.Application.Abstractions.Persistence.Repositories;
using GymOop2024.Application.Models.Models.Entities;
using GymOop2024.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gym_oop_2024.Infrastructure.Persistence.Repositories;

public class UserSubscriptionRepository : BaseRepository<UserSubscription, UserSubscriptionModel>, IUserSubscriptionRepository
{
    private readonly DatabaseContext _context;
    
    public UserSubscriptionRepository(DatabaseContext context, DbSet<UserSubscriptionModel> dbSet) : base(context)
    {
        _context = context;
        DbSet = dbSet;
    }
    
    public UserSubscription GetUserSubscriptionsByUserId(Guid userId)
    {
        var userSubscriptionModel = _context.UserSubscriptions
            .Include(userSubscription => userSubscription.SubscriptionId)
            .Include(userSubscription => userSubscription.User)
            .FirstOrDefault(s => s.UserSubscriptionId == userId);
        
        if (userSubscriptionModel is null)
        {
            throw new Exception();
        }

        return new UserSubscription
        {
            UserSubscriptionId = userSubscriptionModel.UserSubscriptionId,
            SubscriptionId = userSubscriptionModel.SubscriptionId,
            User = userSubscriptionModel.User,
            IsActive = userSubscriptionModel.IsActive,
            IsMulticard = userSubscriptionModel.IsMulticard,
            StartDate = userSubscriptionModel.StartDate,
            EndDate = userSubscriptionModel.EndDate,
        };
    }

    public UserSubscription GetActiveUserSubscriptionsByUserId(Guid userId)
    {
        var userSubscriptionModel = _context.UserSubscriptions
            .Include(userSubscription => userSubscription.SubscriptionId)
            .Include(userSubscription => userSubscription.User)
            .FirstOrDefault(s => s.UserSubscriptionId == userId);
        
        if (userSubscriptionModel is null)
        {
            throw new Exception();
        }

        if (userSubscriptionModel.IsActive is false)
        {
            throw new Exception();
        }
        
        return new UserSubscription
        {
            UserSubscriptionId = userSubscriptionModel.UserSubscriptionId,
            SubscriptionId = userSubscriptionModel.SubscriptionId,
            User = userSubscriptionModel.User,
            IsActive = userSubscriptionModel.IsActive,
            IsMulticard = userSubscriptionModel.IsMulticard,
            StartDate = userSubscriptionModel.StartDate,
            EndDate = userSubscriptionModel.EndDate,
        };
    }

    public IEnumerable<UserSubscription> GetAllUserSubscriptions()
    {
        var userSubModels = _context.UserSubscriptions.Select(model => new UserSubscription
        {
            UserSubscriptionId = model.UserSubscriptionId,
            SubscriptionId = model.SubscriptionId,
            User = model.User,
            IsActive = model.IsActive,
            IsMulticard = model.IsMulticard,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
        }).ToArray();

        return userSubModels;
    }

    public UserSubscription AddUserSubscription(UserSubscription entity)
    {
        _context.UserSubscriptions.Add(entity);

        _context.SaveChanges();

        return entity;
    }

    protected override DbSet<UserSubscriptionModel> DbSet { get; }

    public override UserSubscription Add(UserSubscription entity)
    {
        _context.UserSubscriptions.Add(entity);

        _context.SaveChanges();

        return entity;
    }

    public UserSubscription Update(Guid userSubId, UserSubscription entity)
    {
        var existUserSub = _context.UserSubscriptions.Find(userSubId);

        if (existUserSub is null)
        {
            throw new Exception();
        }

        existUserSub.UserSubscriptionId = entity.UserSubscriptionId;
        existUserSub.SubscriptionId = entity.SubscriptionId;
        existUserSub.User = entity.User;
        existUserSub.IsActive = entity.IsActive;
        existUserSub.IsMulticard = entity.IsMulticard;
        existUserSub.StartDate = entity.StartDate;
        existUserSub.EndDate = entity.EndDate;

        _context.SaveChanges();

        return entity;
    }

    public void Remove(Guid userSubscriptionId)
    {
        var userSubExist = _context.UserSubscriptions.FirstOrDefault(
            s => s.UserSubscriptionId == userSubscriptionId);

        if (userSubExist is null)
        {
            throw new Exception();
        }

        _context.UserSubscriptions.Remove(userSubExist);
        _context.SaveChanges();
    }

    protected override UserSubscriptionModel MapFrom(UserSubscription entity)
    {
        return new UserSubscriptionModel
        {
            UserSubscriptionId = entity.UserSubscriptionId,
            Subscription = entity.SubscriptionId,
            User = entity.User,
            IsActive = entity.IsActive,
            IsMulticard = entity.IsMulticard,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
        };
    }

    protected override bool Equal(UserSubscription entity, UserSubscriptionModel model)
    {
        return entity.UserSubscriptionId.Equals(model.UserSubscriptionId);
    }

    protected override void UpdateModel(UserSubscriptionModel model, UserSubscription entity)
    {
        model.UserSubscriptionId = entity.UserSubscriptionId;
        model.Subscription = entity.SubscriptionId;
        model.User = entity.User;
        model.IsActive = entity.IsActive;
        model.IsMulticard = entity.IsMulticard;
        model.StartDate = entity.StartDate;
        model.EndDate = entity.EndDate;
    }
}