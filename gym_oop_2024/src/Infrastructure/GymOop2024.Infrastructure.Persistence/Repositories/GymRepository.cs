using GymOop2024.Application.Abstractions.Persistence.Repositories;
using GymOop2024.Application.Models;
using GymOop2024.Application.Models.Models.Entities;
using GymOop2024.Infrastructure.Persistence.Contexts;
using GymOop2024.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GymOop2024.Infrastructure.Persistence.Repositories;

public class GymRepository : BaseRepository<Gym, GymModel>, IGymRepository
{
    private readonly DatabaseContext _context;

    public GymRepository(DatabaseContext context, DbSet<GymModel> dbSet) : base(context)
    {
        _context = context;
        DbSet = dbSet;
    }

    protected override DbSet<GymModel> DbSet { get; }
    public override Gym Add(Gym entity)
    {
        var gymModel = MapFrom(entity);
        
        _context.Gyms.Add(gymModel);
        
        _context.SaveChanges();

        return entity;
    }

    protected override GymModel MapFrom(Gym entity)
    {
        return new GymModel
        {
            GymId = entity.GymId,
            GymAddress = entity.GymAddress,
            GymName = entity.GymName,
        };
    }

    protected override bool Equal(Gym entity, GymModel model)
    {
        return entity.GymId.Equals(model.GymId);
    }

    protected override void UpdateModel(GymModel model, Gym entity)
    {
        model.GymId = entity.GymId;
        model.GymAddress = entity.GymAddress;
        model.GymName = entity.GymName;
    }

    public Gym GetById(Guid gymId)
    {
        var gymModel = _context.Gyms.FirstOrDefault(gym => gym.GymId == gymId);

        if (gymModel is null)
        {
            throw new Exception();
        }

        return new Gym
        {
            GymId = gymModel.GymId,
            GymName = gymModel.GymName,
            GymAddress = gymModel.GymAddress,
        };
    }

    public Gym GetGymByAddress(string gymAddress)
    {
        var gymModel = _context.Gyms.FirstOrDefault(gym => gym.GymAddress == gymAddress);

        if (gymModel is null)
        {
            throw new Exception();
        }

        return new Gym
        {
            GymId = gymModel.GymId,
            GymName = gymModel.GymName,
            GymAddress = gymModel.GymAddress,
        };
    }
    
    public IEnumerable<Gym> GetAllGyms()
    {
        var gymModels = _context.Gyms.Select(gymModel => new Gym
        {
            GymId = gymModel.GymId,
            GymName = gymModel.GymName,
            GymAddress = gymModel.GymAddress,
        }).ToArray();

        return gymModels;
    }

    public Gym Update(Guid gymId, Gym entity)
    {
        var existGym = _context.Gyms.Find(gymId);

        if (existGym is null)
        {
            throw new Exception();
        }

        existGym.GymId = entity.GymId;
        existGym.GymName = entity.GymName;
        existGym.GymAddress = entity.GymAddress;

        _context.SaveChanges();

        return entity;
    }
}