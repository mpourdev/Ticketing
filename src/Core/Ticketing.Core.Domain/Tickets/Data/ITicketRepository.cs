using Ticketing.Core.Domain.Shared.Models;
using Ticketing.Core.Domain.Tickets.Entities;

namespace Ticketing.Core.Domain.Tickets.Data;

public interface ITicketRepository
{
    Task<(List<Ticket>, long)> GetAll(PaginationModel model);
    Task<Ticket> GetByIdAsync(long id);
    Task InsertAsync(Ticket entity);
    void Update(Ticket ticket);
    Task CommitAsync();
}