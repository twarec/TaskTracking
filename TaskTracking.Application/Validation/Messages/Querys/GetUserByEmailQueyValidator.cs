using FluentValidation;
using TaskTracking.Application.Messages.Querys;

namespace TaskTracking.Application.Validation.Messages.Querys;

public class GetUserByEmailQueyValidator : AbstractValidator<GetUserByEmailQuey>
{
    public GetUserByEmailQueyValidator()
    {
        RuleFor(_ => _.email)
            .EmailAddress()
            .WithMessage("A valid email is required");
    }
}
