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

        builder.Property(al => al.Name)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(255)");

        builder.Property(al => al.Description)
            .IsRequired()
            .HasColumnName("description")
            .HasMaxLength(255)
            .HasColumnType("VARCHAR(255)");

        builder.Property(al => al.UserId)
            .IsRequired()
            .HasColumnType("userId");

        builder.HasMany(u => u.Assignments)
            .WithOne(a => a.AssignmentList)
            .HasForeignKey(a => a.AssignmentListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}