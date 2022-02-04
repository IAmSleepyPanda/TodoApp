using System;
using System.Threading.Tasks;
using Todo.Domain.Repositories;

namespace Todo.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        private bool disposed = false;

        private readonly TodoDbContext _dbContext;
        

        public UnitOfWork(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<T> GetGenericRepository<T>() where T : class => new GenericRepository<T>(_dbContext);


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _dbContext.Dispose();
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
