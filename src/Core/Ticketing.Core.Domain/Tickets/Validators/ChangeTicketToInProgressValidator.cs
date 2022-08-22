using FluentValidation;
using Ticketing.Core.Domain.Tickets.Commands;

namespace Ticketing.Core.Domain.Tickets.Validators;

public class ChangeTicketToInProgressValidator : AbstractValidator<ChangeTicketToInProgress>
{
    public ChangeTicketToInProgressValidator()
    {
        RuleFor(ticket => ticket.Id)
            .GreaterThan(0);
    }

}