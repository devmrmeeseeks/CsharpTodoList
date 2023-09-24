using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Application.Dtos
{
	public class TodoListDto
	{
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }
    }
}

