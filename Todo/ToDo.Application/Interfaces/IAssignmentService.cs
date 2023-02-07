using ToDo.Application.DTO;
using ToDo.Domain.Models;

namespace ToDo.Application.Interfaces;

public interface IAssignmentService
{
    Task<AssignmentDto> Create(AssignmentDto assignmentDto);
    Task<AssignmentDto> Update(UserDto userDto);
    Task Remove(int id);

    Task<AssignmentDto> Get(int id);
    Task<List<AssignmentDto>> Get();

    Task<AssignmentDto> GetByName(string name);
    Task<List<AssignmentDto>> SearchByName(string name);
    Task<List<AssignmentDto>> SearchByEmail(string email);
    Task<AssignmentDto> GetByEmail(string email);
    Task<AssignmentDto> GetByList(int id);
}