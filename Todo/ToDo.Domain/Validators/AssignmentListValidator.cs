using FluentValidation;
using ToDo.Domain.Models;

namespace ToDo.Domain.Validators;

public class AssignmentListValidator : AbstractValidator<AssignmentList>
{
    public AssignmentListValidator()
    {
        RuleFor(al => al)
            .NotNull()
            .WithMessage("A entidade não pode ser nula")

            .NotEmpty()
            .WithMessage("A entidade não pode ser vazio");

        RuleFor(al => al.Name)
            .NotNull()
            .WithMessage("O nome não pode ser vazio")

            .NotEmpty()
            .WithMessage("O nome não pode ser vazio")

            .MinimumLength(3)
            .WithMessage("O nome deve ter no mínimo 3 caracteres")

            .MaximumLength(255)
            .WithMessage("O nome deve ter no máximo 255 caracteres");

        RuleFor(al => al.Description)
            .NotNull()
            .WithMessage("A descrição não pode ser nulo")

            .NotEmpty()
            .WithMessage("A descrição não pode ser vazio")

            .MinimumLength(3)
            .WithMessage("A descrição deve ter no mínimo 3 caracteres")

            .MaximumLength(255)
            .WithMessage("A descrição deve ter no máximo 255 caracteres");
    }
}