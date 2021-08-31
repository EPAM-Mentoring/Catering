using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.DAL
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetListAsync();
    }
}