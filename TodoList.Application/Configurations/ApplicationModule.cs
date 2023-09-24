using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Services;

namespace TodoList.Application.Configurations
{
	public static class ApplicationModule
	{
		public static IServiceCollection AddApplicationModule(this IServiceCollection services)
		{
            services.AddScoped<ITodoListService, TodoListService>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

			return services;
        }
	}
}

