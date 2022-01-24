using App.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
       
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> Exists(Guid? id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(Guid? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
