    using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infra.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnType("INT");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(20)");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("email")
            .HasColumnType("VARCHAR(255)");

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("password")
            .HasColumnType("VARCHAR(255)");

        builder.HasMany(u => u.Assignments)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.AssignmentLists)
            .WithOne(al => al.User)
            .HasForeignKey(al => al.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}