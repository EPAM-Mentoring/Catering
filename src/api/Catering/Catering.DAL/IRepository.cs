using Catering.DAL.Entities;
using Catering.DAL.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.DAL
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetListAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}