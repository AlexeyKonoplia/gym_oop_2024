using Microsoft.EntityFrameworkCore;

namespace Sample.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() {}
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    public required DbSet<Student> Students { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        // Сюда добавлять различные конфигурации ваших файлов
        base.OnModelCreating(modelBuilder);
    }
}

// Добавил, чтобы видели, примерно какая модель конфигурируется
// public class Student
// {
//     public Guid Id { get; set; }
//     public string? FullName { get; set; }
//     public int Age { get; set; }
// }