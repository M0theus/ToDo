using ToDo.Domain.Models;

namespace ToDo.Domain.Contracts.Repository;

public interface IAssignmentListRepository : IBaseRepository<AssignmentList>
{
    Task<AssignmentList> GetById(int id, int userId);
}