
using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Result;
using BoletosApp.Persistance.Base;
using BoletosApp.Persistance.Context;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoletosApp.Persistance.Repositories.Configuration
{
    public sealed class BusRepository(BoletoContext context, ILogger<BusRepository> logger) : BaseRepository<Bus>(context), IBusRepository
    {
        private readonly BoletoContext context = context;
        private readonly ILogger<BusRepository> logger = logger;

        public async override Task<OperationResult> Save(Bus entity)
        {
            OperationResult result = new OperationResult();

            try
            {

                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "La entidad bus no puede ser nula.";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.NumeroPlaca))
                {
                    result.Success = false;
                    result.Message = "El numero es requerido.";
                    return result;
                }
                if (entity.NumeroPlaca.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El numero de placa no puede ser mayor 50 caracteres.";
                    return result;
                }
                if (await base.Exists(bus => bus.NumeroPlaca == entity.NumeroPlaca))
                {
                    result.Success = false;
                    result.Message = "Existe un autobus con este numero de placa.";
                    return result;
                }

                await base.Save(entity);
            }
            catch (Exception ex)
            {

                result.Message = "Ocurrio un error guardando el autobus";
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Bus entity)
        {
            OperationResult result = new OperationResult();

            try
            {

                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "La entidad bus no puede ser nula.";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.NumeroPlaca))
                {
                    result.Success = false;
                    result.Message = "El numero es requerido.";
                    return result;
                }
                if (entity.NumeroPlaca.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El numero de placa no puede ser mayor 50 caracteres.";
                    return result;
                }
                if (await base.Exists(bus => bus.NumeroPlaca == entity.NumeroPlaca))
                {
                    result.Success = false;
                    result.Message = "Existe un autobus con este numero de placa.";
                    return result;
                }

                await base.Update(entity);
            }
            catch (Exception ex)
            {

                result.Message = "Ocurrio un error guardando el autobus";
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from bus in this.context.Buses
                               where bus.Estatus == true
                               select new BusModel()
                               {
                                   CapacidadPiso1 = bus.CapacidadPiso1,
                                   CapacidadPiso2 = bus.CapacidadPiso2,
                                   Disponible = bus.Disponible,
                                   FechaCreacion = bus.FechaCreacion,
                                   IdBus = bus.IdBus,
                                   Nombre = bus.Nombre,
                                   NumeroPlaca = bus.NumeroPlaca,

                               }).AsNoTracking()
                           .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo los autobuses";
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from bus in this.context.Buses
                               where bus.Estatus == true 
                                && bus.IdBus == Id    
                               select new BusModel()
                               {
                                   CapacidadPiso1 = bus.CapacidadPiso1,
                                   CapacidadPiso2 = bus.CapacidadPiso2,
                                   Disponible = bus.Disponible,
                                   FechaCreacion = bus.FechaCreacion,
                                   IdBus = bus.IdBus,
                                   Nombre = bus.Nombre,
                                   NumeroPlaca = bus.NumeroPlaca,

                               }).AsNoTracking()
                           .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo los autobuses";
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
