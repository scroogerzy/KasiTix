using KasiTix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KasiTix.Infrastructure.Data;

public class KasiTixDbContext : DbContext
{
    public KasiTixDbContext(
        DbContextOptions<KasiTixDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events => Set<Event>();

    public DbSet<TicketType> TicketTypes => Set<TicketType>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderLine> OrderLines => Set<OrderLine>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TicketType>()
            .HasIndex(x => new { x.EventId, x.Name })
            .IsUnique();

        builder.Entity<Order>()
            .HasIndex(x => x.IdempotencyKey)
            .IsUnique();

        builder.Entity<TicketType>()
            .Property(x => x.Version)
            .IsRowVersion();
    }
}