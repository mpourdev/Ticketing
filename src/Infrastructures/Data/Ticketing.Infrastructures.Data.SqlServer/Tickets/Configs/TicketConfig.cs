using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Core.Domain.Tickets.Entities;

namespace Ticketing.Infrastructures.Data.SqlServer.Tickets.Configs;

public class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable(nameof(Ticket));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Text).IsRequired().HasMaxLength(500);
        builder.Property(c => c.CreatedOn).IsRequired();

        builder.HasMany(c => c.TicketStatusHistories)
            .WithOne(e => e.Ticket)
            .HasForeignKey(e => e.TicketId)
            .IsRequired();
    }
}