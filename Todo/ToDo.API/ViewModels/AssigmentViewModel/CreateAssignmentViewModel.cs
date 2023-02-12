using System.ComponentModel.DataAnnotations;

namespace ToDo.API.ViewModels.AssigmentViewModel;

public class CreateAssignmentViewModel
{
    [Required]
    public string Name { get; set; } = null!; //lembrar de colocar lá no notion
    
    [Required]
    public string Description { get; set; } = null!;
    public int? AssignmentListId { get; set; }
    
    public bool Concluded { get; set; }
    public DateTime? ConcludedAt { get; set; }
    public DateTime? Deadline { get; set; }
}