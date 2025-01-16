using FluentValidation;
using TaskTracking.Application.Messages.Commands;

namespace TaskTracking.Application.Validation.Messages.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(_ => _.Name)
            .MaximumLength(50)
            .WithMessage("Max 50");

        RuleFor(_ => _.Email)
            .EmailAddress()
            .WithMessage("A valid email is required");
    }
}
