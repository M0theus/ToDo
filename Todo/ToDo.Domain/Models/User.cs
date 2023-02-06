using ToDo.Core.Exceptions;
using ToDo.Domain.Validators;

namespace ToDo.Domain.Models;

public class User : Base
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    //EF
    public virtual List<Assignment> Assignments { get; set; } = new();
    public virtual List<AssignmentList> AssignmentLists { get; set; } = new();
   
    public User()
    {
    }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        _errors = new List<string>();

        Validate();
    }
    
    public override bool Validate()
    {
        var validator = new UserValidator();
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

    public void ChangeEmail(string email)
    {
        Email = email;
        Validate();
    }

    public void ChangePassword(string password)
    {
        Password = password;
        Validate();
    }
}