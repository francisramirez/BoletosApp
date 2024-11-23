using BoletosApp.Web.Models;

namespace BoletosApp.Web.Service
{
    public interface IBusApiClientService
    {
        Task<BusGetAllResultModel> GetBuses();
    }
}
