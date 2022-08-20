namespace Ticketing.Core.Domain.Tickets.Entities;

public class Ticket
{
    #region Fields

    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Title { get; private set; }
    public string Text { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public IReadOnlyCollection<TicketStatusHistory> TicketStatusHistories { get; private set; }

    #endregion

    #region Constructors

    private Ticket()
    {

    }

    #endregion

    #region Methods



    #endregion
}