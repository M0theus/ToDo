namespace ToDo.Application.DTO;

public class AssignmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; //lembrar de colocar lá no notion
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public int? AssignmentListId { get; set; }
    public bool Concluded { get; set; }
    public DateTime? ConcludedAt { get; set; }
    public DateTime? Deadline { get; set; }

    public AssignmentDto()
    {
    }
    
    public AssignmentDto(string name, string description, int userId, int? assignmentListId, bool concluded, DateTime? concludedAt, DateTime? deadline)
    {
        Name = name;
        Description = description;
        UserId = userId;
        AssignmentListId = assignmentListId;
        Concluded = concluded;
        ConcludedAt = concludedAt;
        Deadline = deadline;
    }
}