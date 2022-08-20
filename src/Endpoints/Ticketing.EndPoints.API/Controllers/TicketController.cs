using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.ApplicationServices.IServices;
using Ticketing.Core.Domain.Shared.Models;
using Ticketing.Core.Domain.Tickets.Commands;

namespace Ticketing.EndPoints.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromQuery] PaginationModel model)
        {
            var result = await _ticketService.GetAll(model);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicket command)
        {
            await _ticketService.Create(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeContent(ChangeTicketContent command)
        {
            await _ticketService.ChangeContent(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeToInProgress(ChangeTicketToInProgress command)
        {
            await _ticketService.ChangeToInProgress(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeToResolved(ChangeTicketToResolved command)
        {
            await _ticketService.ChangeToResolved(command);

            return Ok();
        }

    }
}
