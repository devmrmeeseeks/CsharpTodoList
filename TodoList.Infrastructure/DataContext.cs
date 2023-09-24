using System;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Configurations;

namespace TodoList.Infrastructure
{
	public class DataContext : DbContext
	{
		public DbSet<TodoListData>? TodoLists { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new TodoListConfiguration());
		}
	}
}

