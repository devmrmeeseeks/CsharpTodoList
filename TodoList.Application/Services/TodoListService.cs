using System;
using System.Net;
using System.Runtime.CompilerServices;
using AutoMapper;
using TodoList.Application.Dtos;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Repositories;

namespace TodoList.Application.Services
{
	public class TodoListService : ITodoListService
	{
		private readonly ITodoListRepository _repository;
		private readonly IMapper _mapper;

		public TodoListService(ITodoListRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<TodoListDto>> GetTodoListById(int id)
		{
			var serviceResponse = new ServiceResponse<TodoListDto>();
			var todoList = await _repository.GetTodoListById(id);
			if (todoList is null)
			{
                serviceResponse.Success = false;
				serviceResponse.Message = new string[] { "Todo list not found" };
				return serviceResponse;
			}

			serviceResponse.Data = _mapper.Map<TodoListDto>(todoList);
            return serviceResponse;
        }

		public async Task<ServiceResponse<List<TodoListDto>>> GetAllTodoList()
		{
			var serviceResponse = new ServiceResponse<List<TodoListDto>>();
			var todoLists = await _repository.GetAllTodoLists();
			serviceResponse.Data = todoLists.Select(s => _mapper.Map<TodoListDto>(s)).ToList();
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<TodoListDto>>> CreateTodoList(CreateTodoListDto request)
		{
			var serviceResponse = new ServiceResponse<List<TodoListDto>>();

            var createTodoList = _mapper.Map<TodoListData>(request);
			if (createTodoList.IsValid())
			{
				serviceResponse.Success = false;
				serviceResponse.Message = createTodoList.GetErrors();
				return serviceResponse;
			}

			var todoListsData = await _repository.CreateTodoList(createTodoList);
            serviceResponse.Data = todoListsData.Select(s => _mapper.Map<TodoListDto>(s)).ToList();

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<TodoListDto>>> UpdateTodoList(
				int id,
				UpdateTodoListDto request
		)
		{
			var serviceResponse = new ServiceResponse<List<TodoListDto>>();
			var todoList = _mapper.Map<TodoListData>(request);
			todoList.Id = id;
            if (todoList.IsValid())
			{
				serviceResponse.Success = false;
				serviceResponse.Message = todoList.GetErrors();
				return serviceResponse;
			}

            var todoListsData = await _repository.UpdateTodoList(todoList);
			if (todoListsData is null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = todoList.GetErrors();
				return serviceResponse;
			}

			serviceResponse.Data = todoListsData.Select(s => _mapper.Map<TodoListDto>(s)).ToList();
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<TodoListDto>>> DeleteTodoList(int id)
		{
			var serviceResponse = new ServiceResponse<List<TodoListDto>>();
			var todoListsData = await _repository.DeleteTodoList(id);
			if (todoListsData is null)
			{
				serviceResponse.Message = new string[] { "Todo list not found" };
				return serviceResponse;
			}

			serviceResponse.Data = todoListsData.Select(s => _mapper.Map<TodoListDto>(s)).ToList();
			return serviceResponse;
		}
	}
}
