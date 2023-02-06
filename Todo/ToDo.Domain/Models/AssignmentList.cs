using ToDo.Core.Exceptions;
using ToDo.Domain.Validators;

namespace ToDo.Domain.Models;

public class AssignmentList : Base //ToDo
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!; //lembrar de colocar lá no notion
    public int UserId { get; set; }

    //EF
    public virtual User User { get; set; } = null!;
    public virtual List<Assignment> Assignments { get; set; } = new();

    public AssignmentList()
    {
    }

    public AssignmentList(string name, string description)
    {
        Name = name;
        Description = description;
        _errors = new List<string>();
    }
    public override bool Validate()
    {
        var validator = new AssignmentListValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);

                throw new DomainExceptions("Alguns campos estão inválidos, por favor corrija-os", _errors);
            }
        }

        return true;
    }

    public void ChangeName(string name)
    {
        Name = name;
        Validate();
    }

    public void ChangeDescription(string description)
    {
        Description = description;
        Validate();
    }
}