using FluentValidation;
using Boilerplate.Domain.Entities;

namespace Boilerplate.Application.Validations;

public class BoilerplateValidator : AbstractValidator<BoilerplateEntity>
{
    public BoilerplateValidator()
    {
        RuleFor(x => x.Id == 0)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id field must be filled.");
    }
}
