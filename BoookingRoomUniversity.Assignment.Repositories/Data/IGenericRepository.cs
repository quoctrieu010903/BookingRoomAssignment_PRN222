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
        List<T> GetAll();

        T GetByID(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

}
