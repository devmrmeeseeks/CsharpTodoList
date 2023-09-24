using System;
namespace TodoList.Application.Dtos
{
	public class ServiceResponse<T> where T: class
	{
		public T? Data { get; set; }
		public bool Success { get; set; } = true;
		public IEnumerable<string>? Message { get; set; }
	}
}

