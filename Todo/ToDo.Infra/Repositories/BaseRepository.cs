using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repository;
using ToDo.Domain.Models;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private readonly ToDoContext _context;

    public BaseRepository(ToDoContext context)
    {
        _context = context;
    }
    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<T> Remove(int id)
    {
        var obj = await Get(id);

        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        return obj; //olhar essa parte pq ele quer retornar o banco de dados sem o usuario indicado.
        //provalvelmente vai dar algum erro nessa parte pq eu to retornando o usuario excluido.
    }

    public virtual async Task<T?> Get(int id) //pq o '?' ???
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();

        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
}