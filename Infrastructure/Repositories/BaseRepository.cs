using Core.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly DbSet<T> _context;
        public BaseRepository(InnovationDbContext context)
        {
            _context = context.Set<T>();    
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.FindAsync(id);
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
