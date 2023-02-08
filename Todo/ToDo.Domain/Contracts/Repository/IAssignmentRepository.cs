using ToDo.Domain.Models;

namespace ToDo.Domain.Contracts.Repository;

public interface IAssignmentRepository : IBaseRepository<Assignment>
{
    Task<Assignment> GetById(int id, int userId);
    Task<Assignment> GetByName(string name);
    Task<List<Assignment>> SearchByName(string name);
}