using FluentValidation;
using Costumer.Domain.Entities;

namespace Costumer.Application.Validations;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .WithMessage("Campo nome obrigatório")
            .MinimumLength(3)
            .WithMessage("Campo nome obrigatório");
        RuleFor(p => p.Birthdate)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .LessThan(DateTime.Now)
            .WithMessage("Campo data de nascimento obrigatório");
        RuleFor(p => p.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Campo e-mail obrigatório")
            .NotNull()
            .EmailAddress()
            .WithMessage("O e-mail não está em formato válido.");
    }
}