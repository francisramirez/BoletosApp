

using BoletosApp.Application.Contracts;
using BoletosApp.Application.Dtos.Configuration.Bus;
using BoletosApp.Application.Reponses.Configuration.Bus;
using BoletosApp.Application.Reponses.Configuration.Ruta;
using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Persistance.Base;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Models.Configuration;
using BoletosApp.Persistance.Repositories.Configuration;
using Microsoft.Extensions.Logging;

namespace BoletosApp.Application.Services.Configuration
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        private readonly ILogger<BusService> _logger;

        public BusService(IBusRepository busRepository,
                          ILogger<BusService> logger)
        {
            _busRepository = busRepository;
            _logger = logger;
        }
        public async Task<BusResponse> GetAll()
        {
            BusResponse busResponse = new BusResponse();

            try
            {
                var result = await _busRepository.GetAll();

                if (!result.Success)
                {
                    busResponse.Message = result.Message;
                    busResponse.IsSuccess = result.Success;
                    return busResponse;
                }
               
                busResponse.Data = result.Data;


            }
            catch (Exception ex)
            {

                busResponse.IsSuccess = false;
                busResponse.Message = "Error obteniendo los autobuses";
                _logger.LogError(busResponse.Message,ex.ToString());
                
            }

            return busResponse;
        }

        public async Task<BusResponse> GetById(int Id)
        {
            BusResponse busResponse = new BusResponse();

            try
            {
                var result = await _busRepository.GetEntityBy(Id);

                if (!result.Success)
                {
                    busResponse.Message = result.Message;
                    busResponse.IsSuccess = result.Success;
                    return busResponse;
                }

                busResponse.Data = result.Data;

            }
            catch (Exception ex)
            {

                busResponse.IsSuccess = false;
                busResponse.Message = "Error obteniendo los autobuses";
                _logger.LogError(busResponse.Message, ex.ToString());

            }

            return busResponse;
        }

        public async Task<BusResponse> SaveAsync(BusSaveDto dto)
        {
            BusResponse busResponse = new BusResponse();

            try
            {


                Bus bus = new Bus();
                
                bus.CapacidadPiso1 = dto.CapacidadPiso1;
                bus.CapacidadPiso2 = dto.CapacidadPiso2;
                bus.Disponible = dto.Disponible;
                bus.Estatus = true;
                bus.FechaCreacion = dto.FechaCambio;
                bus.UsuarioModificacion = dto.UsuarioCambio;
                bus.NumeroPlaca = dto.NumeroPlaca;
                bus.Nombre = dto.Nombre;
                
                var result = await _busRepository.Save(bus);
                

                busResponse.Message = result.Message;
                busResponse.IsSuccess = result.Success;   
            }
            catch (Exception ex)
            {

                busResponse.IsSuccess = false;
                busResponse.Message = "Error guardando el autobus.";
                _logger.LogError(busResponse.Message, ex.ToString());
            }

            return busResponse;
        }

        public async Task<BusResponse> UpdateAsync(BusUpdateDto dto)
        {
            BusResponse busResponse = new BusResponse();

            try
            {
                var resultGetById = await _busRepository.GetBusByid(dto.IdBus);

                if (!resultGetById.Success)
                {
                    busResponse.IsSuccess= resultGetById.Success;
                    busResponse.Message = resultGetById.Message;
                    return busResponse;
                }


                Bus bus = (Bus)resultGetById.Data;

                bus.CapacidadPiso1 = dto.CapacidadPiso1;
                bus.CapacidadPiso2 = dto.CapacidadPiso2;
                bus.Disponible = dto.Disponible;
                bus.Estatus = true;
                bus.FechaCreacion = dto.FechaCambio;
                bus.UsuarioModificacion = dto.UsuarioCambio;
                bus.NumeroPlaca = dto.NumeroPlaca;
                bus.Nombre = dto.Nombre;

                var result = await _busRepository.Update(bus);
                result.Message = "El autobus fue actualizado correctamente.";
            }
            catch (Exception ex)
            {

                busResponse.IsSuccess = false;
                busResponse.Message = "Error actualizando el autobus.";
                _logger.LogError(busResponse.Message, ex.ToString());
            }

            return busResponse;
        }
    }
}
