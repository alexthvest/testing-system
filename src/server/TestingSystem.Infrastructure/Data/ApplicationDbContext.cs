using Microsoft.EntityFrameworkCore;
using TestingSystem.Domain.Entities;

namespace TestingSystem.Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Accounts => Set<User>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Teacher> Teachers => Set<Teacher>();

    public DbSet<Group> Groups => Set<Group>();

    public DbSet<Discipline> Disciplines => Set<Discipline>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable(nameof(Students));
        modelBuilder.Entity<Teacher>().ToTable(nameof(Teachers));
    }
}
