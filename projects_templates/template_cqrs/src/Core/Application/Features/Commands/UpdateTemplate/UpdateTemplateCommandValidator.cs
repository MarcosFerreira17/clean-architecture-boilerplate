using FluentValidation;

namespace Application.Features.Commands.UpdateTemplate;

public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
{
    public UpdateTemplateCommandValidator()
    {
        RuleFor(p => p.Example)
            .NotEmpty().WithMessage("{Example} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Example} must not exceed 50 characters.");
    }
}
