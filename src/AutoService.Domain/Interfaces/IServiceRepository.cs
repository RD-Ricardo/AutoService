using AutoService.Core.Data;
using AutoService.Domain.Entities;

namespace AutoService.Domain.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task CreateServiceAsync(Service service);
        Service UpdateServiceAsync(Service service);
    }
}
