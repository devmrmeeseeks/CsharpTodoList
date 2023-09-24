using System;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Repositories
{
	public interface IBaseRepository<E, T> where E : class, IAggregateRoot<T>
    {
        Task<E> Create(E trasienteEntity);
        void Delete(E entity);
        Task<IEnumerable<E>> Get(Func<E, bool> predicate);
        Task<IEnumerable<E>> GetAll();
        Task<E> GetById(T id);
        Task<E> Update(E entity);
    }
}

