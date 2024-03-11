using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Common.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;
        private Hashtable _repositories;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        //public async Task<int> Complete(string userId)
        //{
        //    return await _context.SaveChangesAsync(userId);
        //}

        public void Dispose()
        {
            _context.Dispose();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public IGenericRepository<TEntity, TContext> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<, >);

                //var reposiotryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TContext)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity, TContext>)_repositories[type];

        }
        public async Task<bool> Completed()
        {
            int writtenEntriesCount = await _context.SaveChangesAsync();
            return writtenEntriesCount > 0;
        }
    }
}
