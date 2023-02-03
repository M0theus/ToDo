using ToDo.Domain.Models;

namespace ToDo.Domain.Contracts.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email);
    Task<List<User>> SearchByEmail(string email);
    Task<User> GetByName(string name);
    Task<List<User>> SearchByName(string name);
}