namespace Guiado.Domain.SeedWork
{
    public interface IRepository<T> where T : IRootAgregate
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
