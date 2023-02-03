using ToDo.Domain.Models;

namespace ToDo.Domain.Contracts.Repository;

public interface IBaseRepository<T> where T : Base
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task<T> Remove(int id);
    Task<T?> Get(int id);
    Task<List<T>> Get();
}