using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Common.Repository
{
    public interface IUnitOfWork<TContext>  : IDisposable where TContext: DbContext
    {
        IGenericRepository<TEntity, TContext> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
        Task<bool> Completed();
        //Task<int> Complete(string userId);
    }
}
