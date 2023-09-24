using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Repositories;

namespace TodoList.Infrastructure.Configurations
{
	public static class InfrastructureModule
	{
		public static IServiceCollection AddInfrastructureModule(
            this IServiceCollection services,
            IConfiguration configuration
        )
		{
            services.AddDbContext<DataContext>(options =>
            {
                options
                    .UseMySQL(
                        configuration.GetConnectionString("DefaultConnection")
                    );
            });

            // Configure aggregates roots
            services.AddScoped<IBaseRepository<TodoListData, int>,
				BaseRepository<TodoListData, int>>();

            services.AddScoped<ITodoListRepository, TodoListRepository>();

			return services;
        }
	}
}

