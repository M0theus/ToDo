using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repository;
using ToDo.Domain.Models;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repositories;

public class AssignmentListRepository : BaseRepository<AssignmentList>, IAssignmentListRepository
{
    private readonly ToDoContext _context;
    
    public AssignmentListRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }
    
    public virtual async Task<AssignmentList> GetById(int id, int userId)
    {
        var assignmetList = await _context.Set<AssignmentList>()
            .AsNoTracking()
            .Where(al => al.Id == id && al.UserId == userId)
            .ToListAsync();

        return assignmetList.FirstOrDefault();
    }
}