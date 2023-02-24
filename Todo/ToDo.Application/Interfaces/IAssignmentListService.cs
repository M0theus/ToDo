using ToDo.Application.DTO;

namespace ToDo.Application.Interfaces;

public interface IAssignmentListService
{
    Task<AssignmentListDto> Create(AssignmentListDto assignmentListDto);
    Task<AssignmentListDto> Update(AssignmentListDto assignmentListDto);
    Task<AssignmentListDto> GetByName(string name, int UserId);
    Task<List<AssignmentListDto>> SearchByName(string name);
    Task Remove(int id);
    Task<AssignmentListDto> GetById(int id, int userId);
    Task<List<AssignmentListDto>> GetAll(int userId);
}