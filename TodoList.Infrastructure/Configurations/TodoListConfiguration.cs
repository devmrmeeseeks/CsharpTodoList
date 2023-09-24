using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Configurations
{
	public sealed class TodoListConfiguration : IEntityTypeConfiguration<TodoListData>
	{
		public void Configure(EntityTypeBuilder<TodoListData> builder)
		{
			builder.ToTable("todo_list")
				.HasIndex(s => new { s.Id, s.IsDeleted, s.Title, s.UpdatedAt });

			builder.HasKey(f => f.Id);

			builder.Property(f => f.Id)
				.HasColumnName("id");

			builder.Property(f => f.Title)
				.HasColumnName("title")
				.IsRequired()
				.HasColumnType("nvarchar(50)")
				.HasMaxLength(50);

			builder.Property(f => f.IsDeleted)
				.HasColumnName("is_deleted")
				.HasDefaultValue(false);

			builder.Property(f => f.CreatedAt)
				.HasColumnName("created_at")
				.HasDefaultValueSql("NOW(6)")
				.ValueGeneratedOnAdd();

			builder.Property(f => f.UpdatedAt)
				.HasColumnName("updated_at")
				.HasDefaultValueSql("NOW(6) ON UPDATE NOW(6)")
				.ValueGeneratedOnUpdate();

			builder.HasIndex(s => s.CreatedAt);
        }
	}
}

