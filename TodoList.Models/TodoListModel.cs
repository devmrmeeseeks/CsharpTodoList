using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
	public class TodoListModel
	{
        private string _title;
        private string _content;
        private bool _isValid = true;
        private string _error;

        public int Id { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _isValid = false;
                    _error = "Title is required";
                    return;
                }

                if (value.Length > 200)
                {
                    _isValid = false;
                    _error = "Title must have a maximum size of 200 characters";
                    return;
                }

                _title = value;
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                if (value.Length > 8000)
                {
                    _isValid = false;
                    _error = "Content must have a maximun size of 8000 characters";
                    return;
                }

                _content = value;
            }
        }

        public bool IsValid()
        {
            return _isValid;
        }

        public string GetErrorMessage()
        {
            return _error;
        }
    }
}

