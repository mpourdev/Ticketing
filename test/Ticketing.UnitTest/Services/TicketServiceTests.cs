using AutoMapper;
using Moq;
using System.Threading.Tasks;
using Ticketing.Core.ApplicationServices.Services;
using Ticketing.Core.Domain.Shared.Exceptions;
using Ticketing.Core.Domain.Tickets.Commands;
using Ticketing.Core.Domain.Tickets.Data;
using Ticketing.Core.Domain.Tickets.Entities;
using Xunit;

namespace Ticketing.UnitTest.Services;

public class TicketServiceTests
{
    private readonly TicketService _ticketService;

    private readonly Mock<ITicketRepository> _ticketRepository = new();

    public TicketServiceTests()
    {
        var mapper = new Mock<IMapper>();
        _ticketService = new TicketService(_ticketRepository.Object, mapper.Object);
    }

    [Fact]
    public async Task Create_SendValidData_ReturnsValidResult()
    {
        var command = new CreateTicket("a", "b", "a@a.co", "test", "test msg");
        await _ticketService.Create(command);

        _ticketRepository.Verify(x => x.InsertAsync(It.IsAny<Ticket>()), Times.Once);
        _ticketRepository.Verify(x => x.CommitAsync(), Times.Once);
    }

    [Fact]
    public async Task GetContent_SendValidData_ReturnsValidResponse()
    {
        var command = new ChangeTicketContent(10, "test", "test msg");
        var ticket = new Ticket("a", "b", "a@a.co", "test", "test msg");


        _ticketRepository.Setup(x => x.GetByIdAsync(command.Id))
            .ReturnsAsync(ticket);

        await _ticketService.ChangeContent(command);

        _ticketRepository.Verify(x => x.Update(It.IsAny<Ticket>()), Times.Once);
        _ticketRepository.Verify(x => x.CommitAsync(), Times.Once);
    }

    [Fact]
    public async Task GetContent_TicketInProgress_ThrowsWrongStatusException()
    {
        var command = new ChangeTicketContent(10, "test", "test msg");
        var ticket = new Ticket("a", "b", "a@a.co", "test", "test msg");

        ticket.ChangeToInProgress();

        _ticketRepository.Setup(x => x.GetByIdAsync(command.Id))
            .ReturnsAsync(ticket);


        await Assert.ThrowsAsync<WrongStatusException>(async () => await _ticketService.ChangeContent(command));
    }

    [Fact]
    public async Task GetContent_TicketNotFound_ThrowsNotFoundException()
    {
        var command = new ChangeTicketContent(10, "test", "test msg");

        _ticketRepository.Setup(x => x.GetByIdAsync(command.Id))
            .ReturnsAsync(() => null);


        await Assert.ThrowsAsync<NotFoundException>(async () => await _ticketService.ChangeContent(command));
    }
}