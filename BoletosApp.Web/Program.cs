using BoletosApp.Application.Contracts;
using BoletosApp.Application.Services.Configuration;
using BoletosApp.Persistance.Context;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Repositories.Configuration;
using BoletosApp.Web.Service;
using BoletosApp.Web.Service.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BoletoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BoletoDb")));

builder.Services.AddScoped<IBusRepository, BusRepository>();

builder.Services.AddTransient<IBusService, BusService>();

builder.Services.AddScoped<IRutaRepository, RutaRepository>();

builder.Services.AddTransient<IRutaService, RutaService>();


builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient<IHttpService, HttpService>();

builder.Services.AddTransient<IBusApiClientService, BusApiClientService>();


builder.Services.AddTransient<ISecurityApiService, SecurityApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
