using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);

        Task<T> GetAsync(long id);
        Task CreateAsync(T item);
        Task<T> CreateAsync(long id);
    }
}
