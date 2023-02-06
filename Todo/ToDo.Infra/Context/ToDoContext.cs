using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Models;
using ToDo.Infra.Mappings;

namespace ToDo.Infra.Context;

public class ToDoContext : DbContext
{
    public ToDoContext()
    {
    }

    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Assignment> Assignments  { get; set; }
    public virtual DbSet<AssignmentList> AssignmentLists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
        builder.ApplyConfiguration(new AssignmentMap());
        builder.ApplyConfiguration(new AssignmentListMap());
    }
}