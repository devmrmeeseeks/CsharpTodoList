using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Repositories
{
	public class BaseRepository<E, T>: IBaseRepository<E, T> where E : class, IAggregateRoot<T>
    {
		private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<E> Create(E trasienteEntity)
        {
            var trasientEntity = await _context.Set<E>().AddAsync(trasienteEntity);
            await _context.SaveChangesAsync();
            return trasienteEntity;
        }

        public async void Delete(E entity)
        {
            _context.Set<E>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<E>> Get(Func<E, bool> predicate)
        {
            return await Task.Run(() => _context.Set<E>().Where(predicate));
        }

        public async Task<IEnumerable<E>> GetAll()
        {
            return await Task.Run(() => _context.Set<E>());
        }

        public async Task<E> GetById(T id)
        {
            return await _context.Set<E>().FindAsync(id);
        }

        public async Task<E> Update(E entity)
        {
            var extistingEntity = await _context.Set<E>().FindAsync(entity.Id);
            if (extistingEntity is null)
            {
                return null;
            }

            foreach (var property in typeof(E).GetProperties())
            {
                var newValue = property.GetValue(entity);
                var oldValue = property.GetValue(extistingEntity);
                if (newValue is not null && !Equals(newValue, oldValue))
                {
                    property.SetValue(extistingEntity, newValue);
                }
            }

            await _context.SaveChangesAsync();

            return extistingEntity;
        }
    }
}

