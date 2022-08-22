using FluentValidation;
using Ticketing.Core.Domain.Tickets.Commands;

namespace Ticketing.Core.Domain.Tickets.Validators;

public class ChangeTicketContentValidator : AbstractValidator<ChangeTicketContent>
{
    public ChangeTicketContentValidator()
    {
        RuleFor(ticket => ticket.Id)
            .GreaterThan(0);

        RuleFor(ticket => ticket.Subject)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(ticket => ticket.Message)
            .NotEmpty()
            .MaximumLength(1000);
    }

}