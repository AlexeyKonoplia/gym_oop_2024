using Microsoft.EntityFrameworkCore;
using gym_oop_2024.Application.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace gym_oop_2024.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<DbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; protected init; } = null!;

    public DbSet<UserSubscription> UserSubscriptions { get; protected init; } = null!;

    public DbSet<Subscription> Subscriptions { get; protected init; } = null!;

    public DbSet<Gym> Gyms { get; protected init; } = null!;
    
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