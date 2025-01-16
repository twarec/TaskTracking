using FluentValidation;
using TaskTracking.Application.Messages.Querys;

namespace TaskTracking.Application.Validation.Messages.Querys;

public class GetUserRangeQueryValidator : AbstractValidator<GetUsersRangeQuery>
{
    public GetUserRangeQueryValidator()
    {
        RuleFor(_ => _.Range.Offset)
            .Must(_ => _ >= 0)
            .WithMessage("offser min 0");

        RuleFor(_ => _.Range.Count)
            .Must(_ => _ <= 1000)
            .WithMessage("offser max 1000");
    }
}
