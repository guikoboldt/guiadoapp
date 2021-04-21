using Guiado.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Guiado.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class, IRootAgregate
    {
        private readonly GuiadoContext _context;
        public IUnitOfWork UnitOfWork => this._context;

        public RepositoryBase(GuiadoContext context)
        {
            this._context = context;
        }

        async public ValueTask<T> Add(T entity)
            => (await this._context.Set<T>().AddAsync(entity).ConfigureAwait(false)).Entity;

        public Task<List<T>> GetAll()
            => this._context.Set<T>().ToListAsync();

        public ValueTask<T> Get(int entityID)
            => this._context.Set<T>().FindAsync(entityID);

        public void Remove(T entity)
            => this._context.Set<T>().Remove(entity);

        public void Update(T entity)
            => this._context.Set<T>().Update(entity);
    }
}
