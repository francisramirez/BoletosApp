using BoletosApp.Web.Models.Security;

namespace BoletosApp.Web.Service
{
    public interface ISecurityApiService
    {
        Task<TokenInfo> Register(RegisterModel model);
        Task<TokenInfo> GetToken(LoginModel model);

    }
}
