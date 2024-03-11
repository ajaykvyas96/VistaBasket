using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Common.Repository
{
    public interface IGenericRepository<T, TContext> where T : BaseEntity where TContext : DbContext
    {
        Task<T> GetByIdAsync(Guid? id);
        Task<IReadOnlyList<T>> ListAllAsync();
        void Add(T enitity);
        Task AddAsync(T enitity, string userId);
        void Update(T entity);
        Task UpdateAsync(T entity, string userId);
        void Delete(T entity);
        Task DeleteAsync(T entity, string userId);
        Task AddRange(IEnumerable<T> entity);
        Task AddRangeAsync(IEnumerable<T> entities, string userId);
        void UpdateRange(IEnumerable<T> entity);
        void RemoveRange(IEnumerable<T> entity);
        Task<bool> ContainsAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetListItemsAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        Task<T> GetSingleItemsAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        T GetSingleItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        public Task<IList<T>> GetListItemsAsync(params string[] navigationProperties);
    }
}
