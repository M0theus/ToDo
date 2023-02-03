using FluentValidation;
using ToDo.Domain.Models;

namespace ToDo.Domain.Validators;

public class AssignmentValidator : AbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(a => a)
            .NotNull()
            .WithMessage("A entidade não pode ser vazio")

            .NotEmpty()
            .WithMessage("A entidade não pode ser nula");

        RuleFor(a => a.Description)
            .NotNull()
            .WithMessage("A descrição não pode ser nula")

            .NotEmpty()
            .WithMessage("A descrição não pode ser vazio")

            .MinimumLength(3)
            .WithMessage("A descrição deve ter no mínimo 3 caracteres")

            .MaximumLength(255)
            .WithMessage("A descrição deve ter no máximo 255 caracteres");

        RuleFor(a => a.Name)
            .NotNull()
            .WithMessage("O nome não pode ser nulo")

            .NotEmpty()
            .WithMessage("O nome não pode ser vazio")

            .MinimumLength(3)
            .WithMessage("O nome deve ter no mínimo 3 caracteres")

            .MaximumLength(20)
            .WithMessage("O nome deve ter no máximo 20 caracteres");

        RuleFor(a => a.ConcludedAt)
            .NotNull()
            .WithMessage("O campo 'ConcludedAt' não pode ser nulo")

            .NotEmpty()
            .WithMessage("O campo 'ConcludedAt' não pode ser vazio");

        RuleFor(a => a.AssignmentList)
            .NotNull()
            .WithMessage("O campo 'AssignmentList' não pode ser nulo")

            .NotEmpty()
            .WithMessage("O campo 'AssignmentList' não pode ser vazio");

    }
}