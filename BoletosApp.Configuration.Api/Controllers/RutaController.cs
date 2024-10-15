using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Persistance.Interfaces.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace BoletosApp.Configuration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly IRutaRepository _rutaRepository;

        public RutaController(IRutaRepository rutaRepository)
        {
            _rutaRepository = rutaRepository;
        }
      

        [HttpGet("GetRutas")]
        public async Task<IActionResult> Get()
        {
            var result = await _rutaRepository.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPost("SaveRuta")]
        public async Task<IActionResult> Post([FromBody] Ruta ruta)
        {
            var result = await _rutaRepository.Save(ruta);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT api/<RutaController>/5
        [HttpPost("ModifyRuta")]
        public async Task<IActionResult> Put([FromBody] Ruta ruta)
        {
            var result = await _rutaRepository.Update(ruta);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpPost("DisableRuta")]
        public async Task<IActionResult> DisableRuta(Ruta ruta)
        {
            var result = await _rutaRepository.Remove(ruta);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
