using System.Text.Json.Serialization;

namespace Ticketing.Core.Domain.Tickets.Commands;

public class ChangeTicketToInProgress
{
    [JsonConstructor]
    public ChangeTicketToInProgress(long id)
    {
        Id = id;
    }

    public long Id { get; }
}