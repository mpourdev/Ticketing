using Ticketing.Core.Domain.Tickets.Enums;

namespace Ticketing.Core.Domain.Tickets.Dtos;

public class TicketStatusHistoryDto
{
    public long Id { get; set; }
    public TicketStatus Status { get; set; }
    public DateTime DateTime { get; set; }
}