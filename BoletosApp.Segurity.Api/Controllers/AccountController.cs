using BoletosApp.Segurity.Api.Authentication;
using BoletosApp.Segurity.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BoletosApp.Segurity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AddOrUpdateAppUserModel addOrUpdateApp)
        {
            if (ModelState.IsValid)
            {

                var existedUser = await this.userManager.FindByNameAsync(addOrUpdateApp.UserName);

                if (existedUser is not null)
                {
                    ModelState.AddModelError("", "El usuario ya existe.");
                    return BadRequest(ModelState);
                }

                var user = new AppUser
                {
                    UserName = addOrUpdateApp.UserName,
                    Email = addOrUpdateApp.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var result = await this.userManager.CreateAsync(user, addOrUpdateApp.Password);

                if (result.Succeeded)
                {
                    var token = GenerateToken(addOrUpdateApp.UserName);
                    return Ok(
                        new
                        {
                            token = token.Item1,
                            expire = token.Item2
                        });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("errors:", error.Description);
                }

            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {

                var user = await userManager.FindByNameAsync(loginModel.UserName);

                if (user != null)
                {
                    if (await userManager.CheckPasswordAsync(user, loginModel.Password))
                    {
                        var token = GenerateToken(loginModel.UserName);
                        return Ok(
                           new
                           {
                               token = token.Item1,
                               expire = token.Item2
                           });
                    }
                }
                // If the user is not found, display an error message
                ModelState.AddModelError("Error", "Usuario o clave invalida.");

            }
            return BadRequest(ModelState);

        }
        private (string, DateTime?) GenerateToken(string userName)
        {

            var secret = _configuration["JWTSettings:Key"];
            var issuer = _configuration["JWTSettings:Issuer"];
            var audience = _configuration["JWTSettings:Audience"];
            var durationInMinutes = _configuration["JWTSettings:DurationInMinutes"];

            if (secret is null || issuer is null || audience is null)
            {
                throw new ApplicationException("Jwt is not set in the configuration");
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, userName)

                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = audience,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return (token, tokenDescriptor.Expires);
        }
    }
}
