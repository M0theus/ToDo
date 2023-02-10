using System.ComponentModel.DataAnnotations;

namespace ToDo.API.ViewModels;

public class CreateAssignmentListViewModel
{
    [Required(ErrorMessage = "O nome não pode ser nulo")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres")]
    public string Name { get; set; } = null!;
    
    [Required(ErrorMessage = "A descrição não pode ser nulo" )]
    [MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "A descrição deve ter no máximo 255 caracteres")]
    public string Description { get; set; } = null!; //lembrar de colocar lá no notion
}