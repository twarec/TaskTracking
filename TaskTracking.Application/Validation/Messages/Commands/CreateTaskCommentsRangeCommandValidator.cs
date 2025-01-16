using FluentValidation;
using TaskTracking.Application.Messages.Commands;

namespace TaskTracking.Application.Validation.Messages.Commands;

public class CreateTaskCommentsRangeCommandValidator : AbstractValidator<CreateTaskCommentsRangeCommand>
{
    public CreateTaskCommentsRangeCommandValidator()
    {
        RuleFor(_ => _.Comment)
            .MinimumLength(50)
            .WithMessage("Min 50");

        RuleFor(_ => _.Comment)
            .MaximumLength(1024)
            .WithMessage("Max 1024");
    }
}
