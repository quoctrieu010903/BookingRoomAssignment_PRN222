using System.Linq.Expressions;
using BoookingRoomUniversity.Assignment.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoookingRoomUniversity.Assignment.Repositories.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookingRoomUniversityDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(BookingRoomUniversityDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public IQueryable<T> Entities => _table;

        public void Create(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _table.Attach(entity);
            }
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _table.Find(id);
        }

        public List<T> GetAll()
        {
            return Entities.ToList();
        }
    }
}
