using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Persistance.Interfaces.Configuration;
using Microsoft.AspNetCore.Mvc;


namespace BoletosApp.Configuration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusRepository _busRepository;

        public BusController(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }
      
        [HttpGet("GetBuses")]
        public async Task<IActionResult> Get()
        {
            var result = await _busRepository.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

       
        [HttpGet("GetBusById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _busRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

      
        [HttpPost("SaveBus")]
        public async Task<IActionResult> Post([FromBody] Bus bus)
        {
            var result = await _busRepository.Save(bus);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<BusController>/5
        [HttpPut("UpdateBus")]
        public async Task<IActionResult> Put([FromBody] Bus bus)
        {
            var result = await _busRepository.Update(bus);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
