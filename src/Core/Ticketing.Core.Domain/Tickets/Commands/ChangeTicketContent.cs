using System.Text.Json.Serialization;

namespace Ticketing.Core.Domain.Tickets.Commands;

public class ChangeTicketContent
{
    [JsonConstructor]
    public ChangeTicketContent(long id, string title, string message)
    {
        Title = title;
        Message = message;
        Id = id;
    }

    public long Id { get; }
    public string Title { get; }
    public string Message { get; }
}