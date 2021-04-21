using System.Collections.Generic;
using System.Threading.Tasks;

namespace Guiado.Domain.SeedWork
{
    public interface IRepository<T> where T : IRootAgregate
    {
        IUnitOfWork UnitOfWork { get; }

        ValueTask<T> Add(T entity);

        void Update(T entity);
        Task<List<T>> GetAll();
        ValueTask<T> Get(int entityID);
        void Remove(T entity);
    }
}
