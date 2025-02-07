using RatingService.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingService.Storage.DbContexts;

public class PostgresContext(DbContextOptions<PostgresContext> options) : DbContext(options)
{
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rating>()
            .HasKey(r => r.Id);
    }
}