using System.Text.Json.Serialization;

namespace Ticketing.Core.Domain.Tickets.Commands;

public class ChangeTicketContent
{
    [JsonConstructor]
    public ChangeTicketContent(long id, string subject, string message)
    {
        Id = id;
        Subject = subject;
        Message = message;
    }

    public long Id { get; }
    public string Subject { get; }
    public string Message { get; }
}