using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Dtos;
using TodoList.Application.Services;

namespace TodoList.Controllers
{
	[ApiController]
	[Route("api/todo-list")]
	public class TodoListController : CustomControllerBase
    {
		private readonly ITodoListService _service;

		public TodoListController(ITodoListService service)
		{
			_service = service;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<TodoListDto>>> Get(int id)
		{
			var result = await _service.GetTodoListById(id);
			return result;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<TodoListDto>>>> get()
		{
			var result = await _service.GetAllTodoList();
			return result;
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<List<TodoListDto>>>> put(
				CreateTodoListDto request
		)
		{
			var result = await _service.CreateTodoList(request);
			return result;
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult<ServiceResponse<List<TodoListDto>>>> update(
				int id,
				UpdateTodoListDto request
		)
		{
			var result = await _service.UpdateTodoList(id, request);
			return result;
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ServiceResponse<List<TodoListDto>>>> delete(int id)
		{
			var result = await _service.DeleteTodoList(id);
			return result;
		}
	}
}

