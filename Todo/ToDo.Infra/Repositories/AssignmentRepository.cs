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
}