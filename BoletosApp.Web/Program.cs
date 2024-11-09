using BoletosApp.Application.Contracts;
using BoletosApp.Application.Services.Configuration;
using BoletosApp.Persistance.Context;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BoletoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BoletoDb")));

builder.Services.AddScoped<IBusRepository, BusRepository>();

builder.Services.AddTransient<IBusService, BusService>();

builder.Services.AddControllersWithViews();

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
