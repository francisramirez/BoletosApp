
using BoletosApp.Application.Base;
using BoletosApp.Application.Dtos.Configuration.Bus;
using BoletosApp.Application.Reponses.Configuration.Bus;

namespace BoletosApp.Application.Contracts
{
    public interface IBusService : IBaseService<BusResponse,BusSaveDto,BusUpdateDto>
    {

    }
}
