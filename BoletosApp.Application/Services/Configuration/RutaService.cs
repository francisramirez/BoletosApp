
using BoletosApp.Application.Base;
using BoletosApp.Application.Contracts;
using BoletosApp.Application.Dtos.Configuration.Ruta;
using BoletosApp.Application.Reponses.Configuration.Ruta;
using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Infraestructure.Interfaces;
using BoletosApp.Persistance.Interfaces.Configuration;
using Microsoft.Extensions.Logging;

namespace BoletosApp.Application.Services.Configuration
{
    public class RutaService : IRutaService
    {
        private readonly IRutaRepository _rutaRepository;
        private readonly ILogger<RutaService> _logger;
        private readonly INotificacionService notificacionService;

        public RutaService(IRutaRepository rutaRepository,
                           ILogger<RutaService> logger, INotificacionService notificacionService)
        {
            if (rutaRepository is null)
            {
                throw new ArgumentNullException(nameof(rutaRepository));
            }

            _rutaRepository = rutaRepository;
            _logger = logger;
            this.notificacionService = notificacionService;
        }
        public async Task<RutaResponse> GetAll()
        {
            RutaResponse rutaResponse = new RutaResponse();

            try
            {
                var result = await _rutaRepository.GetAll();






                var notfiyResult = await this.notificacionService.SendEmailAsync(new Infraestructure.Models.EmailModel() 
                {
                     
                });

                if (notfiyResult.Success) 
                {
                    // Guardar en la tabla de notificacion //
                }
                else
                {
                    /// guardar en el log y devu
                   
                }

                List<GetRutaDto> rutas = ((List<Ruta>)result.Data)
                                         .Select(ruta => new GetRutaDto()
                                         {
                                             Destino = ruta.Destino,
                                             Fecha = ruta.FechaCreacion,
                                             Id = ruta.IdRuta,
                                             Origen = ruta.Origen
                                         }).ToList();



                rutaResponse.IsSuccess = result.Success;
                rutaResponse.Model = rutas;
            }
            catch (Exception ex)
            {

                rutaResponse.IsSuccess = false;
                rutaResponse.Message = "Error obteniendo las rutas.";
                _logger.LogError(rutaResponse.Message, ex.ToString());

            }

            return rutaResponse;
        }

        public async Task<RutaResponse> GetById(int Id)
        {
            RutaResponse rutaResponse = new RutaResponse();

            try
            {
                var result = await _rutaRepository.GetEntityBy(Id);

                Ruta ruta = (Ruta)result.Data;

                GetRutaDto rutaDto = new GetRutaDto()
                {
                    Destino = ruta.Destino,
                    Origen = ruta.Origen,
                    Id = ruta.IdRuta,
                    Fecha = ruta.FechaCreacion,
                };

                rutaResponse.IsSuccess = result.Success;
                rutaResponse.Model = rutaDto;
            }
            catch (Exception ex)
            {

                rutaResponse.IsSuccess = false;
                rutaResponse.Message = "Error obteniendo la ruta.";
                _logger.LogError(rutaResponse.Message, ex.ToString());
            }

            return rutaResponse;
        }

        public async Task<RutaResponse> SaveAsync(RutaSaveDto dto)
        {
                RutaResponse rutaResponse = new RutaResponse();

                try
                {
                    Ruta ruta = new Ruta();

                    ruta.Destino = dto.Destino;
                    ruta.Origen = dto.Origen;
                    ruta.FechaCreacion = dto.FechaCambio;
                    ruta.UsuarioModificacion = dto.UsuarioCambio;

                    var result = await _rutaRepository.Save(ruta);
                }
                catch (Exception ex)
                {

                    rutaResponse.IsSuccess = false;
                    rutaResponse.Message = "Error guardando la ruta.";
                    _logger.LogError(rutaResponse.Message, ex.ToString());
                }

                return rutaResponse;
        }

        public async Task<RutaResponse> UpdateAsync(RutaUpdateDto dto)
        {
            RutaResponse rutaResponse = new RutaResponse();

            try
            {
                var resultEntity = await _rutaRepository.GetEntityBy(dto.IdRuta);

                Ruta rutaToUpdate = (Ruta)resultEntity.Data;

                rutaToUpdate.Destino = dto.Destino;
                rutaToUpdate.Origen = dto.Origen;
                rutaToUpdate.FechaCreacion = dto.FechaCambio;
                rutaToUpdate.UsuarioModificacion = dto.UsuarioCambio;

                var result = await _rutaRepository.Update(rutaToUpdate);
            }
            catch (Exception ex)
            {

                rutaResponse.IsSuccess = false;
                rutaResponse.Message = "Error obteniendo la ruta.";
                _logger.LogError(rutaResponse.Message, ex.ToString());
            }

            return rutaResponse;
        }
    }
}
