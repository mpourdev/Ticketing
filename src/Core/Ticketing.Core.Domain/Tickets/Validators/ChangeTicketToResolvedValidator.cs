using FluentValidation;
using Ticketing.Core.Domain.Tickets.Commands;

namespace Ticketing.Core.Domain.Tickets.Validators;

public class ChangeTicketToResolvedValidator : AbstractValidator<ChangeTicketToResolved>
{
    public ChangeTicketToResolvedValidator()
    {
        RuleFor(ticket => ticket.Id)
            .GreaterThan(0);
    }

}