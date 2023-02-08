namespace ToDo.Application.DTO;

public class AssignmentListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!; //lembrar de colocar lá no notion
    public int UserId { get; set; }

    public AssignmentListDto()
    {
    }
    
    public AssignmentListDto(int id, string name, string description, int userId)
    {
        Id = id;
        Name = name;
        Description = description;
        UserId = userId;
    }
}