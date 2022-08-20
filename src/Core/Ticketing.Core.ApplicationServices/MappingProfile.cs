using AutoMapper;
using Ticketing.Core.Domain.Tickets.Dtos;
using Ticketing.Core.Domain.Tickets.Entities;

namespace Ticketing.Core.ApplicationServices;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ticket, TicketDetailDto>();
        CreateMap<Ticket, TicketDto>();

        CreateMap<TicketStatusHistory, TicketStatusHistoryDto>();
    }

}