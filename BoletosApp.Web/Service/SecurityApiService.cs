using Azure;
using BoletosApp.Web.Models.Security;
using BoletosApp.Web.Service.Base;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net.Http;

namespace BoletosApp.Web.Service
{
    public class SecurityApiService : ISecurityApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SecurityApiService> _logger;
        private string urlBase;
        public SecurityApiService(HttpClient httpClient,
                                  ILogger<SecurityApiService> logger,
                                  IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
             urlBase = configuration["ApiConfig:UrlBaseSec"];

        }
        public async Task<TokenInfo> GetToken(LoginModel model)
        {
            TokenInfo? tokenInfo = new TokenInfo();

            try
            {
                _httpClient.BaseAddress = new Uri(urlBase);
                var response = await _httpClient.PostAsJsonAsync("Account/login", model);
                response.EnsureSuccessStatusCode();
                tokenInfo = await response.Content.ReadFromJsonAsync<TokenInfo>();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error obteniendo el token", ex.ToString());
                tokenInfo = null;
            }

            return tokenInfo;
        }

        public Task<TokenInfo> Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
