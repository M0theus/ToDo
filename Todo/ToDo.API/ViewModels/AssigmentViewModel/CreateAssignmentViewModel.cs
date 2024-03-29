using System.ComponentModel.DataAnnotations;

namespace ToDo.API.ViewModels.AssigmentViewModel;

public class CreateAssignmentViewModel
{
    [Required(ErrorMessage = "O nome não pode ser vazio")]
    [MinLength(3, ErrorMessage = "O deve ter no mínimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "O nome deve ter no máximo 255 carcateres")]
    public string Name { get; set; } = null!; //lembrar de colocar lá no notion
    
    [Required(ErrorMessage = "A descrição não pode ser vazio")]
    [MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "A descrição deve ter no máximo 255 carcateres")]
    public string Description { get; set; } = null!;
    
    [Required(ErrorMessage = "O AssignmentListId não pode ser vazio")]
    public int? AssignmentListId { get; set; }
    
    public bool Concluded { get; set; }
    public DateTime? ConcludedAt { get; set; }
    public DateTime? Deadline { get; set; }
}