using Common.Models.Enums;
using ReservationService.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationService.Storage.DbContexts;

public class PostgresContext(DbContextOptions<PostgresContext> options) : DbContext(options)
{
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Reservation>()
            .Property(r => r.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        modelBuilder.Entity<Reservation>()
            .ToTable(t => t.HasCheckConstraint("CHK_Reservation_Status", "\"Status\" IN ('RENTED', 'RETURNED', 'EXPIRED')"));
    }
}