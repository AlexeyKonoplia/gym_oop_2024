using GymOop2024.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymOop2024.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TModel> where TModel : class
{
    private readonly DatabaseContext _context;

    protected BaseRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    protected abstract DbSet<TModel> DbSet { get; }
    
    public abstract TEntity Add(TEntity entity);
    
    protected abstract TModel MapFrom(TEntity entity);
    
    public void AddRange(IEnumerable<TEntity> entities)
    {
        IEnumerable<TModel> models = entities.Select(MapFrom);
        DbSet.AddRange(models);
    }
    public void Update(TEntity entity)
    {
        EntityEntry<TModel> entry = GetEntry(entity);
        UpdateModel(entry.Entity, entity);

        entry.State = EntityState.Modified;
    }

    public void Remove(TEntity entity)
    {
        EntityEntry<TModel> entry = GetEntry(entity);
        entry.State = entry.State is EntityState.Added ? EntityState.Detached : EntityState.Deleted;
    }

    protected abstract bool Equal(TEntity entity, TModel model);

    protected abstract void UpdateModel(TModel model, TEntity entity);

    private EntityEntry<TModel> GetEntry(TEntity entity)
    {
        TModel? existing = DbSet.Local.FirstOrDefault(model => Equal(entity, model));

        return existing is not null
            ? _context.Entry(existing)
            : DbSet.Attach(MapFrom(entity));
    }
}