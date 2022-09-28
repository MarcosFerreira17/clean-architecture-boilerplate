using FluentValidation;

namespace Application.Features.Commands.CreateTemplate;

public class CreateTemplateCommandValidator : AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateCommandValidator()
    {
        RuleFor(p => p.Example)
            .NotEmpty().WithMessage("{Example} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Example} must not exceed 50 characters.");
    }
}
