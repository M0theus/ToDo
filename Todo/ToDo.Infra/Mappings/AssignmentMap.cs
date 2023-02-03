using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infra.Mappings;

public class AssignmentMap : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("Assignment");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(20)");

        builder.Property(a => a.UserId)
            .IsRequired()
            .HasColumnName("userId");

        builder.Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("VARCHAR(20)");

        builder.Property(a => a.AssignmentListId)
            .IsRequired(false);

        builder.Property(a => a.Concluded)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnType("TINYINT");

        builder.Property(a => a.ConcludedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME");

        builder.Property(a => a.Deadline)
            .IsRequired(false)
            .HasColumnType("DATETIME");
    }
}