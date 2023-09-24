using System;
namespace TodoList.Domain.Entities
{
	public interface IAggregateRoot<T>
	{
		public T Id { get; set; }
	}
}

