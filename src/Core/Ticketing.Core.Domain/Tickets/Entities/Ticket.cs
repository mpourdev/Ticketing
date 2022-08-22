using Ticketing.Core.Domain.Shared;
using Ticketing.Core.Domain.Shared.Exceptions;
using Ticketing.Core.Domain.Shared.ValueObjects;
using Ticketing.Core.Domain.Tickets.Enums;

namespace Ticketing.Core.Domain.Tickets.Entities;

public class Ticket : IAggregateRoot
{

    #region Fields

    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
    public string Subject { get; private set; }
    public string Message { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public TicketStatus Status { get; private set; }

    private readonly ICollection<TicketStatusHistory> _ticketStatusHistories;

    public IReadOnlyCollection<TicketStatusHistory> TicketStatusHistories
    {
        get => (IReadOnlyCollection<TicketStatusHistory>)_ticketStatusHistories;
        private init => _ticketStatusHistories = (ICollection<TicketStatusHistory>)value;
    }

    #endregion

    #region Constructors

    private Ticket()
    {

    }

    public Ticket(string firstName, string lastName, string email, string subject, string message)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 50)
            throw new ArgumentException($"{nameof(subject)} is invalid.");

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 50)
            throw new ArgumentException($"{nameof(message)} is invalid.");

        if (string.IsNullOrWhiteSpace(subject) || subject.Length > 200)
            throw new ArgumentException($"{nameof(subject)} is invalid.");

        if (string.IsNullOrWhiteSpace(message) || message.Length > 1000)
            throw new ArgumentException($"{nameof(message)} is invalid.");

        //Id = Guid.NewGuid();
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = Email.FromString(email);
        Subject = subject;
        Message = message;
        CreatedOn = DateTime.Now;
        Status = TicketStatus.Opened;

        TicketStatusHistories = new List<TicketStatusHistory>
        {
            new(TicketStatus.Opened)
        };
    }

    #endregion

    #region Methods

    public void ChangeContent(string subject, string message)
    {
        if (string.IsNullOrWhiteSpace(subject) || subject.Length > 200)
            throw new ArgumentException($"{nameof(subject)} is invalid.");

        if (string.IsNullOrWhiteSpace(message) || message.Length > 1000)
            throw new ArgumentException($"{nameof(message)} is invalid.");

        if (Status != TicketStatus.Opened)
            throw new WrongStatusException();

        Subject = subject;
        Message = message;
    }

    public void ChangeToInProgress()
    {
        if (Status != TicketStatus.Opened)
            throw new WrongStatusException();

        Status = TicketStatus.InProgress;
        _ticketStatusHistories.Add(new TicketStatusHistory(TicketStatus.InProgress));
    }

    public void ChangeToResolved()
    {
        if (Status != TicketStatus.InProgress)
            throw new WrongStatusException();

        Status = TicketStatus.Resolved;
        _ticketStatusHistories.Add(new TicketStatusHistory(TicketStatus.Resolved));
    }

    #endregion

}