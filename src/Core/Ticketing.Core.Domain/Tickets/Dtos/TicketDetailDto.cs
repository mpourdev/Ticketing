using Ticketing.Core.Domain.Tickets.Enums;

namespace Ticketing.Core.Domain.Tickets.Dtos;

public class TicketDetailDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedOn { get; set; }
    public TicketStatus Status { get; set; }

    public List<TicketStatusHistoryDto> TicketStatusHistories { get; set; }
}