using BoookingRoomUniversity.Assignment.Repositories.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace BoookingRoomUniversity.Assignment.Repositories.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingRoomUniversityDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BookingRoomUniversityDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _context.SaveChanges();
                _transaction.Commit();
            }
            catch
            {
                RollBack();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void RollBack()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
