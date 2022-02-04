using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Domain.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly TodoDbContext _dbContext;

        public GenericRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Create(T item)
        {
            _dbContext.Add<T>(item);
        }
        

        public void Delete(int id)
        {
            var item = Get(id);

            if (item != null)
                _dbContext.Remove<T>(item);
        }

        public async Task<T> GetAsync(long id)
        {;
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task CreateAsync(T item)
        {
            await _dbContext.AddAsync(item);
        }

        public async Task<T> CreateAsync(long id)
        {
            return await _dbContext.FindAsync<T>(id);
        }


        public T Get(int id)
        {
            return _dbContext.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }
        
        
        public void Update(T item)
        {
            _dbContext.Update<T>(item);
        }
        
    }
}
