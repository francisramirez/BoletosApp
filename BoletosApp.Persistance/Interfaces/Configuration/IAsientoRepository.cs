using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Repositories;
using BoletosApp.Domain.Result;


namespace BoletosApp.Persistance.Interfaces.Configuration
{
    public interface IAsientoRepository : IBaseRepository<Asiento>
    {
        List<OperationResult> GetAsientoByBusId(int busId);
    }
}
