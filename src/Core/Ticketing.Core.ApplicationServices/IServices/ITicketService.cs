using Ticketing.Core.Domain.Shared.Dtos;
using Ticketing.Core.Domain.Shared.Models;
using Ticketing.Core.Domain.Tickets.Commands;
using Ticketing.Core.Domain.Tickets.Dtos;

namespace Ticketing.Core.ApplicationServices.IServices;

public interface ITicketService
{
    Task<PagedListDto<TicketDto>> GetAll(PaginationModel model);
    Task<TicketDetailDto> GetById(long id);
    Task Create(CreateTicket command);
    Task ChangeContent(ChangeTicketContent command);
    Task ChangeToInProgress(ChangeTicketToInProgress command);
    Task ChangeToResolved(ChangeTicketToResolved command);
}