using Domain.Accounts;
using Domain.Employees;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Account> Accounts { get; set; } = null!;
  public DbSet<UserProfile> UserProfiles { get; set; } = null!;
  public DbSet<Employee> Employees { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // Account mapping
    modelBuilder.Entity<Account>(b =>
    {
      b.ToTable("Accounts");
      b.HasKey(a => a.Id);
      b.Property(a => a.Email).IsRequired().HasMaxLength(256);
      b.Property(a => a.PasswordHash).IsRequired().HasMaxLength(512);
      b.Property(a => a.CreatedAt).IsRequired();
      b.HasIndex(a => a.Email).IsUnique();
    });

    // UserProfile mapping
    modelBuilder.Entity<UserProfile>(b =>
    {
      b.ToTable("UserProfiles");
      b.HasKey(u => u.Id);
      b.Property(u => u.FullName).HasMaxLength(200);
      b.Property(u => u.Bio).HasMaxLength(1000);
      b.HasOne<Account>()
           .WithOne(a => a.Profile)
           .HasForeignKey<UserProfile>(u => u.AccountId)
           .OnDelete(DeleteBehavior.Cascade);
    });

    // Employee mapping
    modelBuilder.Entity<Employee>(b =>
    {
      b.ToTable("Employees");
      b.HasKey(e => e.Id);
      b.Property(e => e.Name).IsRequired().HasMaxLength(200);
      b.Property(e => e.Position).HasMaxLength(100);
      b.Property(e => e.Salary).HasColumnType("decimal(18,2)");
    });
  }
}
