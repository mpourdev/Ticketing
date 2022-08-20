using Ticketing.Core.Domain.Tickets.Enums;

namespace Ticketing.Core.Domain.Tickets.Entities;

public class TicketStatusHistory
{
    #region Fields

    public long Id { get; private set; }
    public long TicketId { get; private set; }
    public TicketStatus Status { get; private set; }
    public DateTime DateTime { get; private set; }
    public Ticket Ticket { get; private set; }

    #endregion

    #region Constructors

    private TicketStatusHistory()
    {

    }

    public TicketStatusHistory(TicketStatus status)
    {
        //Id = Guid.NewGuid();
        Status = status;
        DateTime = DateTime.Now;
    }

    #endregion

    #region Methods



    #endregion
}