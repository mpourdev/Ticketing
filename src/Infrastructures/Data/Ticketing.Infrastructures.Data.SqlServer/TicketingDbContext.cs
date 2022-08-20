using Microsoft.EntityFrameworkCore;
using Ticketing.Core.Domain.Tickets.Entities;

namespace Ticketing.Infrastructures.Data.SqlServer;

public class TicketingDbContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; }


    public TicketingDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}