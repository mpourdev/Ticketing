using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Core.Domain.Tickets.Entities;

namespace Ticketing.Infrastructures.Data.SqlServer.Tickets.Configs;

public class TicketStatusHistoryConfig : IEntityTypeConfiguration<TicketStatusHistory>
{
    public void Configure(EntityTypeBuilder<TicketStatusHistory> builder)
    {
        builder.ToTable(nameof(TicketStatusHistory));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.TicketId).IsRequired();
        builder.Property(c => c.Status).IsRequired();
        builder.Property(c => c.DateTime).IsRequired();
    }
}