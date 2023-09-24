using System;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Repositories
{
	public interface ITodoListRepository
	{
		Task<List<TodoListData>> GetAllTodoLists();
		Task<TodoListData?> GetTodoListById(int id);
		Task<List<TodoListData>> CreateTodoList(TodoListData element);
		Task<List<TodoListData>?> DeleteTodoList(int id);
		Task<List<TodoListData>?> UpdateTodoList(TodoListData todoList);
    }
}
