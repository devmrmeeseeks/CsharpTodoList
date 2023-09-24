using System;
using AutoMapper;
using TodoList.Application.Dtos;
using TodoList.Domain.Entities;

namespace TodoList.Application.Configurations
{
	public sealed class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<TodoListData, TodoListDto>();
			CreateMap<CreateTodoListDto, TodoListData>();
			CreateMap<UpdateTodoListDto, TodoListData>();
		}
	}
}
