using System;
namespace TodoList.Domain
{
	public abstract class Validator
	{
        private IEnumerable<string> _errors { get; set; } = Enumerable.Empty<string>();

        public bool IsValid()
        {
            var validations = Validate();
            if (validations.Any())
            {
                _errors = validations;
            }

            return validations.Any();
        }

        public IEnumerable<string> GetErrors()
        {
            return _errors;
        }

        protected abstract IEnumerable<string> Validate();
    }
}

