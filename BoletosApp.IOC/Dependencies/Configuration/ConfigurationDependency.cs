using Microsoft.Extensions.DependencyInjection;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Repositories.Configuracion;
using BoletosApp.Persistance.Repositories.Configuration;
using BoletosApp.Application.Contracts;
using BoletosApp.Application.Services.Configuration;


namespace BoletosApp.IOC.Dependencies.Configuration
{
    public static class ConfigurationDependency
    {
        public static void AddConfigurationDependency(this IServiceCollection service) 
        {
            service.AddScoped<IAsientoRepository, AsientoRepository>();

            service.AddScoped<IBusRepository, BusRepository>();

            service.AddScoped<IRutaRepository, RutaRepository>();

            service.AddTransient<IBusService,BusService>();
        }
    }
}
