using System;
using System.Threading.Tasks;
using Todo.Domain.Repositories;

namespace Todo.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetGenericRepository<T>() where T : class;

        void Save();
        Task SaveAsync();
    }
}
