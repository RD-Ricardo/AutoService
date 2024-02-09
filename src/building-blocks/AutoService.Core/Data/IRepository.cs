using AutoService.Core.DomainObjects;

namespace AutoService.Core.Data
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
