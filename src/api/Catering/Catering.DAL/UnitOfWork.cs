using Catering.DAL.DbContexts;
using Catering.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CateringDbContext _dbContext; 
        private Hashtable _repositories;

        public UnitOfWork(CateringDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChangeAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
