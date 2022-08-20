using System.Text.Json.Serialization;

namespace Ticketing.Core.Domain.Tickets.Commands;

public class CreateTicket
{
    [JsonConstructor]
    public CreateTicket(string firstName, string lastName, string email, string title, string message)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Title = title;
        Message = message;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Title { get; }
    public string Message { get; }
}