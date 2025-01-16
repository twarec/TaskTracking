using Microsoft.EntityFrameworkCore;
using TaskTracking.Domain.Entity;

namespace TaskTracking.Application.Services;

public class DatabaseContext : DbContext
{
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TaskUserEntity> TaskUsers { get; set; }
    public DbSet<TaskCommentEntity> Comments { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<TaskEntity>()
            .HasIndex(_ => new
            {
                _.Status,
                _.Weight,
                _.DateCreate
            });

        modelBuilder
            .Entity<TaskCommentEntity>()
            .HasIndex(_ => _.DateCreated);

        modelBuilder
            .Entity<UserEntity>()
            .HasIndex(_ => _.Email)
            .IsUnique();

        modelBuilder
            .Entity<UserEntity>()
            .HasIndex(_ => _.Name);

        modelBuilder
            .Entity<UserEntity>()
            .HasIndex(_ => _.DateCreate);

        modelBuilder
            .Entity<TaskUserEntity>()
            .HasIndex(_ => new
            {
                _.TaskId,
                _.UserId,
            }).IsUnique();
    }
}
