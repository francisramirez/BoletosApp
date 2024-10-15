using BoletosApp.Persistance.Context;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Repositories.Configuracion;
using BoletosApp.Persistance.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BoletoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BoletoDb")));

//El registro de cada una de las dependecias Repositorios de configuration. //
builder.Services.AddScoped<IAsientoRepository, AsientoRepository>();
builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<IRutaRepository, RutaRepository>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
