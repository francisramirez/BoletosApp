using BoletosApp.Web.Models;
using BoletosApp.Web.Service.Base;

namespace BoletosApp.Web.Service
{
    public class BusApiClientService : IBusApiClientService
    {
        private readonly IHttpService _httpService;
        private readonly ILogger<BusApiClientService> _logger;
        private readonly IConfiguration _configuration;
      

        public BusApiClientService(IHttpService httpService,
                                   ILogger<BusApiClientService> logger
                                   )
        {
            _httpService = httpService;
            _logger = logger;
          
            
        }
        public async Task<BusGetAllResultModel> GetBuses()
        {
            BusGetAllResultModel busGetAllResultModel = new BusGetAllResultModel();
            try
            {
                busGetAllResultModel = await _httpService.GetAsync<BusGetAllResultModel>("Bus/GetBuses");
            }
            catch (Exception ex)
            {
                busGetAllResultModel.isSuccess = false;
                busGetAllResultModel.message = "Error obteniendo los buses";
                _logger.LogError($"{ busGetAllResultModel.message } { ex.ToString() }");
            }
            return busGetAllResultModel;
        }
    }
}
