using Azure;
using BoletosApp.Application.Dtos.Configuration.Bus;
using BoletosApp.Web.Models;
using BoletosApp.Web.Service.Base;

namespace BoletosApp.Web.Service
{
    public class BusApiClientService : IBusApiClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BusApiClientService> _logger;
        private readonly IConfiguration _configuration;
        private string urlBase; 
      

        public BusApiClientService(HttpClient httpClient,
                                   ILogger<BusApiClientService> logger, 
                                   IConfiguration configuration
                                   )
        {
            _httpClient = httpClient;
            _logger = logger;
            urlBase = configuration["ApiConfig:UrlBase"];



        }
        public async Task<BusGetAllResultModel> GetBuses(string token)
        {
            BusGetAllResultModel busGetAllResultModel = new BusGetAllResultModel();
            try
            {
                _httpClient.BaseAddress = new Uri(urlBase);
               
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response = await _httpClient.GetAsync("Bus/GetBuses");
               
                response.EnsureSuccessStatusCode();

                busGetAllResultModel = await response.Content.ReadFromJsonAsync<BusGetAllResultModel>();
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
