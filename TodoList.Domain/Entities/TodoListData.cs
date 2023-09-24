namespace TodoList.Domain.Entities
{
	public class TodoListData : Validator, IAggregateRoot<int> 
    {
		public int Id { get; set; }

		public string? Title { get; set; }

		public bool IsDeleted { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }

		public virtual IEnumerable<TodoItemData> Items { get; set; } = Enumerable.Empty<TodoItemData>();


		protected override IEnumerable<string> Validate()
		{
            if (string.IsNullOrEmpty(Title))
			{
				yield return $"{nameof(Title)} is required";
			}
			else if (Title.Length > 50)
			{
				yield return $"{nameof(Title)} must be 50 characters or fewer";
			}
        }
    }
}

