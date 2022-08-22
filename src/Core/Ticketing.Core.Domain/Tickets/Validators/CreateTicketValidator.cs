using FluentValidation;
using Ticketing.Core.Domain.Tickets.Commands;

namespace Ticketing.Core.Domain.Tickets.Validators;

public class CreateTicketValidator : AbstractValidator<CreateTicket>
{
    public CreateTicketValidator()
    {
        RuleFor(ticket => ticket.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(ticket => ticket.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(ticket => ticket.Email)
            .NotEmpty()
            .MaximumLength(50)
            .EmailAddress();

        RuleFor(ticket => ticket.Subject)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(ticket => ticket.Message)
            .NotEmpty()
            .MaximumLength(1000);
    }

}