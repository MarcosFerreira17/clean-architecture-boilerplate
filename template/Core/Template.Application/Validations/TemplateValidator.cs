using FluentValidation;
using Template.Domain.Entities;

namespace Template.Application.Validations;

public class TemplateValidator : AbstractValidator<TemplateEntity>
{
    public TemplateValidator()
    {
        RuleFor(x => x.Id == 0)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id field must be filled.");
    }
}
