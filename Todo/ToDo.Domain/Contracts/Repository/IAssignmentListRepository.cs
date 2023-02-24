using ToDo.Domain.Models;

namespace ToDo.Domain.Contracts.Repository;

public interface IAssignmentListRepository : IBaseRepository<AssignmentList>
{ 
    Task<AssignmentList> GetById(int id, int userId);
    Task<List<AssignmentList>> SearchByName(string name);
    Task<AssignmentList> GetByName(string name, int userId);
    Task<List<AssignmentList>> GetAll(int userId);
}