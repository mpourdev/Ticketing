using System.Text.Json.Serialization;

namespace Ticketing.Core.Domain.Tickets.Commands;

public class ChangeTicketContent
{
    [JsonConstructor]
    public ChangeTicketContent(long id, string subject, string message)
    {
        Subject = subject;
        Message = message;
        Id = id;
    }

    public long Id { get; }
    public string Subject { get; }
    public string Message { get; }
}