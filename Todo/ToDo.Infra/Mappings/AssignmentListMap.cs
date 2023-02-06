using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infra.Mappings;

public class AssignmentListMap : IEntityTypeConfiguration<AssignmentList>
{
    public void Configure(EntityTypeBuilder<AssignmentList> builder)
    {
        builder.ToTable("AssignmentList");

        builder.HasKey(al => al.Id);

        builder.Property(c => c.Id)
            .IsRequired();
        
        builder.Property(al => al.Name)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("VARCHAR(255)");

        builder.Property(al => al.Description)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("VARCHAR(255)");

        builder.Property(al => al.UserId)
            .IsRequired();

        builder.HasMany(u => u.Assignments)
            .WithOne(a => a.AssignmentList)
            .OnDelete(DeleteBehavior.Restrict);
    }
}