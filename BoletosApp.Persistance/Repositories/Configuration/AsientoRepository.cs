using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Result;
using BoletosApp.Persistance.Base;
using BoletosApp.Persistance.Context;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoletosApp.Persistance.Repositories.Configuracion
{
    public class AsientoRepository : BaseRepository<Asiento>, IAsientoRepository
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<AsientoRepository> logger;

        public AsientoRepository(BoletoContext boletoContext,
                                 ILogger<AsientoRepository> logger) : base(boletoContext)
        {
            _boletoContext = boletoContext;
            this.logger = logger;
        }

        public async override Task<OperationResult> Save(Asiento entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }

            if (entity.NumeroPiso <= 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El número de piso no puede ser menor o igual a cero.";
                return operationResult;
            }

            if (entity.NumeroAsiento <= 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El número de asiento no puede ser menor o igual a cero.";
                return operationResult;
            }

            if (entity.IdBus == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El bus es requerido.";
                return operationResult;
            }



            if (await base.Exists(asiento => asiento.NumeroPiso == entity.NumeroPiso
                                  && asiento.NumeroAsiento == entity.NumeroAsiento))
            {
                operationResult.Success = false;
                operationResult.Message = "El asiento se encuentra registrado.";
                return operationResult;
            }



            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error guardando el asiento.";
                logger.LogError(operationResult.Message, ex.ToString());

            }
            return operationResult;

        }
        public async override Task<OperationResult> Update(Asiento entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }
            if (entity.IdAsiento <= 0)
            {
                operationResult.Success = false;
                operationResult.Message = "Se requiere enviar el asiento id para realizar esta operación.";
                return operationResult;
            }
            if (entity.NumeroPiso <= 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El número de piso no puede ser menor o igual a cero.";
                return operationResult;
            }

            if (entity.NumeroAsiento <= 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El número de asiento no puede ser menor o igual a cero.";
                return operationResult;
            }

            if (entity.IdBus == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El bus es requerido.";
                return operationResult;
            }


            try
            {
                Asiento? asientoToUpdate = await _boletoContext.Asientos.FindAsync(entity.IdAsiento);


                asientoToUpdate.NumeroAsiento = entity.NumeroAsiento;
                asientoToUpdate.NumeroPiso = entity.NumeroPiso;
                asientoToUpdate.IdBus = entity.IdBus;
                asientoToUpdate.UsuarioModificacion = entity.UsuarioModificacion;

                operationResult = await base.Update(asientoToUpdate);
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error actualizando el asiento.";
                logger.LogError(operationResult.Message, ex.ToString());

            }
            return operationResult;
        }
        public async override Task<OperationResult> Remove(Asiento entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }

            if (entity.IdAsiento <= 0)
            {
                operationResult.Success = false;
                operationResult.Message = "Se requiere enviar el asiento id para realizar esta operación.";
                return operationResult;
            }
            try
            {
                Asiento? asientoToRemove = await _boletoContext.Asientos.FindAsync(entity.IdAsiento);
                asientoToRemove.Estatus = false;
                asientoToRemove.FechaModificacion = entity.FechaModificacion;
                asientoToRemove.UsuarioModificacion = entity.UsuarioModificacion;

                await base.Update(asientoToRemove);

            }
            catch (Exception ex)
            {

                operationResult.Success = false;
                operationResult.Message = "Error desactivando el asiento.";
                logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {

                operationResult.Data = await (from asiento in _boletoContext.Asientos
                                              join bus in _boletoContext.Buses on asiento.IdBus equals bus.IdBus
                                              where asiento.Estatus == true
                                              orderby asiento.FechaCreacion descending
                                              select new AsientoBusModel()
                                              {
                                                  AsientoId = asiento.IdAsiento,
                                                  Bus = bus.Nombre,
                                                  BusId = bus.IdBus,
                                                  FechaCreacion = bus.FechaCreacion,
                                                  FechaModificacion = bus.FechaModificacion,
                                                  NumeroAsiento = asiento.NumeroAsiento,
                                                  NumeroPiso = asiento.NumeroPiso,
                                                  UsuarioModificacion = asiento.UsuarioModificacion
                                              }).ToListAsync(); ;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error obteniendo los asientos";
                logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult operationResult = new OperationResult();

            try
            {

                operationResult.Data = await (from asiento in _boletoContext.Asientos
                                              join bus in _boletoContext.Buses on asiento.IdBus equals bus.IdBus
                                              where asiento.Estatus == true
                                               && asiento.IdAsiento == Id
                                              select new AsientoBusModel()
                                              {
                                                  AsientoId = asiento.IdAsiento,
                                                  Bus = bus.Nombre,
                                                  BusId = bus.IdBus,
                                                  FechaCreacion = bus.FechaCreacion,
                                                  FechaModificacion = bus.FechaModificacion,
                                                  NumeroAsiento = asiento.NumeroAsiento,
                                                  NumeroPiso = asiento.NumeroPiso,
                                                  UsuarioModificacion = asiento.UsuarioModificacion
                                              }).FirstOrDefaultAsync(); ;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error obteniendo el asiento.";
                logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public List<OperationResult> GetAsientoByBusId(int busId)
        {
            throw new NotImplementedException();
        }
    }
}
