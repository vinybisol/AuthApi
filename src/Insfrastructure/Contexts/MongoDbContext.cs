using Domain.Models;
using Infrastructure.EFEntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public sealed class MongoDbContext(DbContextOptions<MongoDbContext> options) : DbContext(options)
{
    public DbSet<LoginModel> Logins => Set<LoginModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new LoginConfiguration().Configure(modelBuilder.Entity<LoginModel>());
        base.OnModelCreating(modelBuilder);
    }
}
