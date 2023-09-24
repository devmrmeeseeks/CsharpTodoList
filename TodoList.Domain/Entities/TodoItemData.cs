using System;
namespace TodoList.Domain.Entities
{
	public class TodoItemData : Validator
	{
		public int Id { get; set; }
		public string? Content { get; set; }
		public bool IsCompleted { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }

		protected override IEnumerable<string> Validate()
		{
			if (Content?.Length > 200)
			{
				yield return $"{nameof(Content)} must be 200 characters of fewer";

			}
		}
	}
}

