using AutoMapper;
using Ticketing.Core.ApplicationServices.IServices;
using Ticketing.Core.Domain.Shared.Dtos;
using Ticketing.Core.Domain.Shared.Exceptions;
using Ticketing.Core.Domain.Shared.Models;
using Ticketing.Core.Domain.Tickets.Commands;
using Ticketing.Core.Domain.Tickets.Data;
using Ticketing.Core.Domain.Tickets.Dtos;
using Ticketing.Core.Domain.Tickets.Entities;

namespace Ticketing.Core.ApplicationServices.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public TicketService(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<PagedListDto<TicketDto>> GetAll(PaginationModel model)
    {
        var (list, total) = await _ticketRepository.GetAll(model);

        return new PagedListDto<TicketDto>
        {
            Total = total,
            PageSize = model.PageSize,
            PageIndex = model.PageIndex,
            List = _mapper.Map<List<TicketDto>>(list)
        };
    }

    public async Task<TicketDetailDto> GetById(long id)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id);
        return _mapper.Map<TicketDetailDto>(ticket);
    }

    public async Task Create(CreateTicket command)
    {
        var ticket = new Ticket(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Subject,
            command.Message
        );
        await _ticketRepository.InsertAsync(ticket);
        await _ticketRepository.CommitAsync();
    }

    public async Task ChangeContent(ChangeTicketContent command)
    {
        var ticket = await _ticketRepository.GetByIdAsync(command.Id);

        if (ticket is null)
            throw new NotFoundException();

        ticket.ChangeContent(command.Subject, command.Message);

        _ticketRepository.Update(ticket);
        await _ticketRepository.CommitAsync();
    }

    public async Task ChangeToInProgress(ChangeTicketToInProgress command)
    {
        var ticket = await _ticketRepository.GetByIdAsync(command.Id);

        if (ticket is null)
            throw new NotFoundException();

        ticket.ChangeToInProgress();

        _ticketRepository.Update(ticket);
        await _ticketRepository.CommitAsync();
    }

    public async Task ChangeToResolved(ChangeTicketToResolved command)
    {
        var ticket = await _ticketRepository.GetByIdAsync(command.Id);

        if (ticket is null)
            throw new NotFoundException();

        ticket.ChangeToResolved();

        _ticketRepository.Update(ticket);
        await _ticketRepository.CommitAsync();
    }

}