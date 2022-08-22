using Microsoft.EntityFrameworkCore;
using Ticketing.Core.Domain.Shared.Models;
using Ticketing.Core.Domain.Tickets.Data;
using Ticketing.Core.Domain.Tickets.Entities;

namespace Ticketing.Infrastructures.Data.SqlServer.Tickets;

public class EfTicketRepository : ITicketRepository
{
    private readonly TicketingDbContext _dbContext;

    public EfTicketRepository(TicketingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(List<Ticket>, long)> GetAll(PaginationModel model)
    {
        var total = await _dbContext.Tickets.LongCountAsync();
        var list = await _dbContext.Tickets.AsNoTracking()
            .OrderBy(t => t.CreatedOn)
            .Skip(model.PageIndex * model.PageSize)
            .Take(model.PageSize)
            .ToListAsync();

        return (list, total);
    }

    public async Task<Ticket> GetByIdAsync(long id)
    {
        return await _dbContext.Tickets
            .Where(t => t.Id == id)
            .Include(t => t.TicketStatusHistories)
            .SingleOrDefaultAsync();
    }

    public async Task InsertAsync(Ticket entity)
    {
        await _dbContext.Tickets.AddAsync(entity);
    }

    public void Update(Ticket ticket)
    {
        _dbContext.Tickets.Update(ticket);
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

}