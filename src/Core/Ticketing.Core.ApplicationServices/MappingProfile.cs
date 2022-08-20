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
        //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

        CreateMap<TicketStatusHistory, TicketStatusHistoryDto>();
    }

}