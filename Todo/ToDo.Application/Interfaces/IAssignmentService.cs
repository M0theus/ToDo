using ToDo.Application.DTO;

namespace ToDo.Application.Interfaces;

public interface IAssignmentService
{
    Task<AssignmentDto> Create(AssignmentDto assignmentDto);
    Task<AssignmentDto> Update(AssignmentDto assignmentDto);
    Task Remove(int id);
    Task<AssignmentDto> Get(int id);
    Task<List<AssignmentDto>> Get();
    Task<AssignmentDto> GetByName(string name);
    Task<List<AssignmentDto>> SearchByName(string name);
}