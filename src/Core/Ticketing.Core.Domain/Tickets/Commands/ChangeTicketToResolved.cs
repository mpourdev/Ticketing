namespace Ticketing.Core.Domain.Tickets.Commands;

public class ChangeTicketToResolved
{
    public ChangeTicketToResolved(long id)
    {
        Id = id;
    }

    public long Id { get; }
}