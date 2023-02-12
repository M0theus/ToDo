using System.ComponentModel.DataAnnotations;

namespace ToDo.API.ViewModels.UserViewModel;

public class CreateUserViewModel
{
    [Required(ErrorMessage = "O nome não pode ser nulo")]
    [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres")]
    [MaxLength(20, ErrorMessage = "O nome deve ter no máxmo 20 caracteres")]
    public string Name { get; set; } = null!;
    
    [Required(ErrorMessage = "O Email não pode ser nulo")]
    [MinLength(3, ErrorMessage = "O email deve conter no mínimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "A senha não pode ser nula")]
    [MinLength(3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres")]
    public string Password { get; set; } = null!;
}