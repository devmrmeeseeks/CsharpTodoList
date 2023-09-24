using System;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Repositories
{
	public class TodoListRepository : ITodoListRepository 
	{
		private readonly IBaseRepository<TodoListData, int> _baseRepository;

        public TodoListRepository(IBaseRepository<TodoListData, int> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<List<TodoListData>> CreateTodoList(TodoListData todoList)
        {
            await _baseRepository.Create(todoList);
            return await GetAllTodoLists();
        }

        public async Task<List<TodoListData>> GetAllTodoLists()
        {
            var todoList = await _baseRepository.GetAll();
            if (todoList is null)
            {
                return new List<TodoListData>();
            }

            return todoList.ToList();
        }

        public async Task<TodoListData?> GetTodoListById(int id)
        {
            var todoList = await _baseRepository.GetById(id);
            return todoList;
        }

        public async Task<List<TodoListData>?> DeleteTodoList(int id)
        {
            var todoList = await GetTodoListById(id);
            if (todoList is null)
            {
                return null;
            }

            _baseRepository.Delete(todoList);

            return await GetAllTodoLists();
        }

        public async Task<List<TodoListData>?> UpdateTodoList(TodoListData todoList)
        {
            var todoListData = await GetTodoListById(todoList.Id);
            if (todoListData is null)
            {
                return null;
            }

            await _baseRepository.Update(todoList);

            return await GetAllTodoLists();
        }
    }
}

