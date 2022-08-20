using Ticketing.Core.Domain.Shared.Exceptions;
using Ticketing.Core.Domain.Tickets.Enums;

namespace Ticketing.Core.Domain.Tickets.Entities;

public class Ticket
{

    #region Fields

    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Title { get; private set; }
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

    public Ticket(string firstName, string lastName, string email, string title, string message)
    {
        //Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Title = title;
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

    public void ChangeContent(string title, string message)
    {
        //if (string.IsNullOrWhiteSpace(title))
        //    throw new ArgumentNullException(nameof(title));

        //if (string.IsNullOrWhiteSpace(message))
        //    throw new ArgumentNullException(nameof(message));

        //if (title.Length > 100)
        //    throw new ArgumentOutOfRangeException(nameof(title));

        //if (title.Length > 100)
        //    throw new ArgumentOutOfRangeException(nameof(message));

        Title = title;
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