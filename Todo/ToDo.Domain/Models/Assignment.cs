using ToDo.Domain.Validators;

namespace ToDo.Domain.Models;

public class Assignment : Base //Task
{
    public string Name { get; set; } = null!; //lembrar de colocar lá no notion
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public int AssignmentListId { get; set; }
    public bool Concluded { get; set; }
    public DateTime? ConcludedAt { get; set; }
    public DateTime? Deadline { get; set; }

    //EF
    public virtual User User { get; set; } = null!;
    public virtual AssignmentList AssignmentList { get; set; } = null!;

    public Assignment()
    {
    }

    public Assignment(string name, string description)
    {
        Name = name;
        Description = description;
        _errors = new List<string>();
    }
    
    public override bool Validate()
    {
        var validator = new AssignmentValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);

                throw new Exception("Alguns campos estão inválidos, por favor corrija-os" + _errors[0]);
            }
        }

        return true;
    }

    public void MarcarComoConcluido()
    {
        ConcludedAt = DateTime.Now;
        Concluded = true;
    }

    public void MarcarComoNaoConcluido()
    {
        ConcludedAt = null;
        Concluded = false;
    }

    public void ChangeName(string name)
    {
        Name = name;
        Validate();
    }

    public void ChangeDeadLine(DateTime dateChange)
    {
        Deadline = dateChange;
        Validate();
    }

    public void ChangeDescription(string description)
    {
        Description = description;
        Validate();
    }
}