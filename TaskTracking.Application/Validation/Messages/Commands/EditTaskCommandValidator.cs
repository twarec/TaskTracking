using FluentValidation;
using TaskTracking.Application.Messages.Commands;

namespace TaskTracking.Application.Validation.Messages.Commands;

public class EditTaskCommandValidator : AbstractValidator<EditTaskCommand>
{
    public EditTaskCommandValidator()
    {
        RuleFor(_ => _.Description)
            .MaximumLength(1024)
            .WithMessage("Max 1024");

        RuleFor(_ => _.Name)
            .MaximumLength(50)
            .WithMessage("Max 50");

        RuleFor(_ => _.Weight)
            .Must(_ => _ >= 0 && _ <= 100)
            .WithMessage("Min 0 and max 100");
    }
}
