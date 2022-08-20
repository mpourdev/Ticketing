using Ticketing.Core.Domain.Tickets.Enums;

namespace Ticketing.Core.Domain.Tickets.Dtos;

public class TicketStatusHistoryDto
{
    public TicketStatus Status { get; set; }
    public DateTime DateTime { get; set; }
}