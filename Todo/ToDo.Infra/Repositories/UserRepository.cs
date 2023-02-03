using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repository;
using ToDo.Domain.Models;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ToDoContext _context;
    
    public UserRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<User> GetByEmail(string email)
    {
        var user = await _context.Set<User>()
            .AsNoTracking()
            .Where(u => u.Email.ToLower() == email)
            .ToListAsync();

        return user.FirstOrDefault(); //olhar depois, ele quer retornar uma lista!!
    }

    public virtual async Task<List<User>> SearchByEmail(string email)
    {
        var allUser = await _context.Set<User>()
            .Where(u => u.Email.ToLower().Contains(email.ToLower()))
            .AsNoTracking()
            .ToListAsync();

        return allUser;
    }

    public virtual async Task<User> GetByName(string name)
    {
        var user = await _context.Set<User>()
            .AsNoTracking()
            .Where(u => u.Name == name)
            .ToListAsync();

        return user.FirstOrDefault(); //aqui ele tbm quer retornar uma lista!!
    }

    public virtual async Task<List<User>> SearchByName(string name)
    {
        var allUser = await _context.Set<User>()
            .AsNoTracking()
            .Where(u => u.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();

        return allUser;
    }
}