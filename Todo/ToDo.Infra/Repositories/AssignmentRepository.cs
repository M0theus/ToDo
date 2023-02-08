using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repository;
using ToDo.Domain.Models;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{
    private readonly ToDoContext _context;
    
    public AssignmentRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<Assignment> GetById(int id, int userId)
    {
        var assignmentTask = await _context.Set<Assignment>()
            .AsNoTracking()
            .Where(a => a.Id == id && a.UserId == userId)
            .ToListAsync();

        return assignmentTask.FirstOrDefault();
    }

    public virtual async Task<Assignment> GetByName(string name)
    {
        var assignmentExists = await _context.Set<Assignment>()
            .AsNoTracking()
            .Where(a => a.Name == name)
            .ToListAsync();

        return assignmentExists.FirstOrDefault();
    }

    public virtual async Task<List<Assignment>> SearchByName(string name)
    {
        var allAssignment = await _context.Set<Assignment>()
            .AsNoTracking()
            .Where(a => a.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();

        return allAssignment;
    }
}