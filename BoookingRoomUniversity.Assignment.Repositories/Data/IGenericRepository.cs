using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoookingRoomUniversity.Assignment.Repositories.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        IQueryable<T> FindAll(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByID(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
