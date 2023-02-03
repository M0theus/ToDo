using FluentValidation;
using ToDo.Domain.Models;

namespace ToDo.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u)
            .NotNull()
            .WithMessage("A entidade não pode ser vazio")

            .NotEmpty()
            .WithMessage("A entidade não pode ser nulo");

        RuleFor(u => u.Name)
            .NotNull()
            .WithMessage("O nome não pode ser nulo")

            .NotEmpty()
            .WithMessage("O nome não pode ser vazio")

            .MinimumLength(2)
            .WithMessage("O nome deve ter no mínimo 2 caracteres")

            .MaximumLength(20)
            .WithMessage("O nome deve ter no máxmo 20 caracteres");

        RuleFor(u => u.Password)
            .NotNull()
            .WithMessage("A senha não pode ser nula")

            .NotEmpty()
            .WithMessage("A senha não pode ser vazio")

            .MinimumLength(3)
            .WithMessage("A senha deve ter no mínimo 3 caracteres")

            .MaximumLength(255)
            .WithMessage("A senha deve ter no máximo 255 caracteres");

        RuleFor(u => u.Email)
            .NotNull()
            .WithMessage("O Email não pode ser nulo")

            .NotEmpty()
            .WithMessage("A senha não pode ser vazio")

            .MinimumLength(3)
            .WithMessage("O email deve conter no mínimo 3 caracteres")

            .MaximumLength(255)
            .WithMessage("A senha deve ter no máximo 255 caracteres")

            .EmailAddress()
            .WithMessage("O email não é valido");
    }
}