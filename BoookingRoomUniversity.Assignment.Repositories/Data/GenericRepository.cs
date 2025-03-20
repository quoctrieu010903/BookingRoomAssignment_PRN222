using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BoookingRoomUniversity.Assignment.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoookingRoomUniversity.Assignment.Repositories.Data
{
    public class GenericRepository<T>  : IGenericRepository<T> where T : class
    {
        private readonly BookingRoomUniversityContext _context;
        private DbSet<T> _table = null;

        public GenericRepository(BookingRoomUniversityContext context)
        {
            _context = context;
            _table = _context.Set<T>(); ;
        }

        public IQueryable<T> Entities => _table;

      
        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _table.Attach(entity);
            }
            _table.Remove(entity);

        }

        public async Task Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;



        }
        public IQueryable<T> FindAll(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>().AsNoTracking(); // Importance Always include AsNoTracking for Query Side
            if (includeProperties != null)
                foreach (var includeProperty in includeProperties)
                    items = items.Include(includeProperty);

            if (predicate is not null)
                items = items.Where(predicate);

            return items;
        }

        public async Task<List<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByID(int id) => await _table.FindAsync(id);


    }
}
