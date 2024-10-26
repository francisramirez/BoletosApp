

using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Repositories;
using BoletosApp.Domain.Result;

namespace BoletosApp.Persistance.Interfaces.Configuration
{
    public interface IBusRepository : IBaseRepository<Bus>
    {
         Task<OperationResult> GetBusByid(int busId);
    }
}
