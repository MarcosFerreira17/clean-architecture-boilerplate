using Costumer.Domain.ValueObjects;
using FluentValidation;

namespace Costumer.Application.Validations;
public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.State)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(25)
            .WithMessage("Campo obrigatório");
        RuleFor(a => a.City)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(20)
            .WithMessage("Campo obrigatório");
        RuleFor(a => a.Neighborhood)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(30)
            .WithMessage("Campo obrigatório");
        RuleFor(a => a.Street)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(20)
            .WithMessage("Campo obrigatório");
        RuleFor(a => a.Number)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotEqual(0)
            .WithMessage("Endereco");
        RuleFor(a => a.Complement);
    }
}