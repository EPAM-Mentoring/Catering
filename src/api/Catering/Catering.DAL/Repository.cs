using Catering.DAL.DbContexts;
using Catering.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CateringDbContext _dbContext;

        private DbSet<T> _dbSet;

        private DbSet<T> DbSet => _dbSet ??= _dbContext.Set<T>();

        public Repository(CateringDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<T> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(_ => (_ as BaseEntity).Id == id);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}
