using Base30.Core.DomainObjects;

namespace Base30.Core.Data
{
    public interface IRepository<T>: IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }

    
}
