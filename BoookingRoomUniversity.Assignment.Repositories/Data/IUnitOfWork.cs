using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoookingRoomUniversity.Assignment.Repositories.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
