using System.Text.Json.Serialization;

namespace Ticketing.Core.Domain.Tickets.Commands;

public class CreateTicket
{
    [JsonConstructor]
    public CreateTicket(string firstName, string lastName, string email, string subject, string message)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Subject = subject;
        Message = message;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Subject { get; }
    public string Message { get; }
}