using System.Text.Json.Serialization;

namespace Ticketing.Core.Domain.Tickets.Commands;

public class ChangeTicketToResolved
{
    [JsonConstructor]
    public ChangeTicketToResolved(long id)
    {
        Id = id;
    }

    public long Id { get; }
}