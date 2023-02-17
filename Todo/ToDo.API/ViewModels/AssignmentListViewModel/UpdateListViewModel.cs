using System.ComponentModel.DataAnnotations;

namespace ToDo.API.ViewModels.AssignmentListViewModel;

public class UpdateListViewModel
{
    [Required(ErrorMessage = "O nome da list não pode ser vazio")]
    [MinLength(3, ErrorMessage = "O nome da list deve ter no minimo 3 caracteres")]
    [MaxLength(180, ErrorMessage = "O nome da list deve ter no maximo 180 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A descrição da list não pode ser vazio")]
    [MinLength(3, ErrorMessage = "A descrição da list deve ter no minimo 3 caracteres")]
    [MaxLength(180, ErrorMessage = "A descrição da list deve ter no maximo 180 caracteres")]
    public string Description { get; set; }
}