

using BoletosApp.Application.Base;
using BoletosApp.Application.Dtos.Configuration.Ruta;
using BoletosApp.Application.Reponses.Configuration.Ruta;

namespace BoletosApp.Application.Contracts
{
    public interface IRutaService : IBaseService<RutaResponse, RutaSaveDto, RutaUpdateDto>
    {
    }
}
