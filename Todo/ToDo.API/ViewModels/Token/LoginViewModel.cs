using System.ComponentModel.DataAnnotations;

namespace ToDo.API.ViewModels.Token;

public class LoginViewModel
{
    [Required(ErrorMessage = "O nome não pode ser vazio")]
    public string Name { get; set; } = null!;
    
    [Required(ErrorMessage = "A senha não pode ser vazio")]
    public string Password { get; set; } = null!;
}