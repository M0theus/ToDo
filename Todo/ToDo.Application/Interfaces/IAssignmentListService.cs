using ToDo.Application.DTO;

namespace ToDo.Application.Interfaces;

public interface IAssignmentListService
{
    Task<AssignmentListDto> Create(AssignmentListDto assignmentListDto);
    Task<AssignmentListDto> Update(AssignmentListDto assignmentListDto);
    Task<AssignmentListDto> GetByName(string name);
    Task<List<AssignmentListDto>> SearchByName(string name);
    Task Remove(int id);
}