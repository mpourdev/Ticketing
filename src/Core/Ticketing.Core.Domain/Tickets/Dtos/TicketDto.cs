using Ticketing.Core.Domain.Tickets.Enums;

namespace Ticketing.Core.Domain.Tickets.Dtos;

public class TicketDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime CreatedOn { get; set; }
    public TicketStatus Status { get; set; }
}