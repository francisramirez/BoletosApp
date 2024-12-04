using BoletosApp.Persistance.Context;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Repositories.Configuracion;
using BoletosApp.Persistance.Repositories.Configuration;
using BoletosApp.IOC.Dependencies.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BoletoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BoletoDb")));

//El registro de cada una de las dependecias Repositorios de configuration. //
builder.Services.AddConfigurationDependency();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Configuracion Boletos API",
        Description = "Api para la administracion de la aplicacion de boletos",
       
        Contact = new OpenApiContact
        {
            Name = "JOSE PEREZ",
            Email = "jperez@gmail.com",
            Url = new Uri("https://twitter.com/spboyer"),
        }
       
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });



});


#region"Token Config"

var key = Encoding.ASCII.GetBytes(builder.Configuration["JWTSettings:Key"]);

builder.Services.AddAuthentication(jb =>
{
    jb.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    jb.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie()
  .AddJwtBearer(jb =>
  {
      jb.RequireHttpsMetadata = false;
      jb.SaveToken = true;
      jb.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
      };
  });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
