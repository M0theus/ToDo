namespace ToDo.Domain.Filter;

public class AssignmentFilter
{
    public string Description { get; set; }
    public DateTime? StartDeadLine { get; set; }
    public DateTime? EndDeadLine { get; set; }
    public bool Concluded { get; set; }
    public string OrderBy { get; set; } = "description";
    public string OrderDir { get; set; } = "asc";
}