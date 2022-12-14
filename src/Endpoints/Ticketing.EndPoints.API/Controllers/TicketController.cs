using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.ApplicationServices.IServices;
using Ticketing.Core.Domain.Shared.Models;
using Ticketing.Core.Domain.Tickets.Commands;

namespace Ticketing.EndPoints.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginated([FromQuery] PaginationModel model)
        {
            var result = await _ticketService.GetAll(model);

            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _ticketService.GetById(id);

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

        [HttpPatch("{id:long}")]
        public async Task<IActionResult> ChangeToInProgress(long id)
        {
            await _ticketService.ChangeToInProgress(new ChangeTicketToInProgress(id));

            return Ok();
        }

        [HttpPatch("{id:long}")]
        public async Task<IActionResult> ChangeToResolved(long id)
        {
            await _ticketService.ChangeToResolved(new ChangeTicketToResolved(id));

            return Ok();
        }

    }
}
