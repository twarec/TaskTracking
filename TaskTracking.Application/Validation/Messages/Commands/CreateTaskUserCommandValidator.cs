using FluentValidation;
using TaskTracking.Application.Messages.Commands;

namespace TaskTracking.Application.Validation.Messages.Commands;

public class CreateTaskUserCommandValidator : AbstractValidator<CreateTaskUserCommand>
{
    public CreateTaskUserCommandValidator()
    {
    }
}
