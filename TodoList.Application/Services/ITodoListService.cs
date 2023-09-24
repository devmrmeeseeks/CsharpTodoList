using System;
using System.Threading.Tasks;
using TodoList.Application.Dtos;

namespace TodoList.Application.Services
{
	public interface ITodoListService
	{
        Task<ServiceResponse<TodoListDto>> GetTodoListById(int id);
        Task<ServiceResponse<List<TodoListDto>>> GetAllTodoList();
        Task<ServiceResponse<List<TodoListDto>>> CreateTodoList(CreateTodoListDto request);
        Task<ServiceResponse<List<TodoListDto>>> UpdateTodoList(
                int id,
                UpdateTodoListDto request
        );
        Task<ServiceResponse<List<TodoListDto>>> DeleteTodoList(int id);
    }
}

