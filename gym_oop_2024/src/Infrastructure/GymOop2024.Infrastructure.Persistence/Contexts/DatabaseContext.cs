using GymOop2024.Application.Models;
using GymOop2024.Application.Models.Models.Entities;
using GymOop2024.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GymOop2024.Infrastructure.Persistence.Contexts;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected DatabaseContext(DbContextOptions options) : base(options) { }

    public DbSet<UserModel> Users { get; protected init; } = null!;

    public DbSet<UserSubscription> UserSubscriptions { get; protected init; } = null!;

    public DbSet<SubscriptionModel> Subscriptions { get; protected init; } = null!;

    public DbSet<GymModel> Gyms { get; protected init; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (IMutableForeignKey fk in cascadeFKs)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
    }
}

// Добавил, чтобы видели, примерно какая модель конфигурируется
// public class Student
// {
//     public Guid Id { get; set; }
//     public string? FullName { get; set; }
//     public int Age { get; set; }
// }