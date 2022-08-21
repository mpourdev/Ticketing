namespace Ticketing.Core.Domain.Tickets.Commands;

public class ChangeTicketToInProgress
{
    public ChangeTicketToInProgress(long id)
    {
        Id = id;
    }

    public long Id { get; }
}