using BoletosApp.Application.Contracts;
using BoletosApp.Application.Dtos.Configuration.Bus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BoletosApp.Configuration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpGet("GetBuses")]
        public async Task<IActionResult> Get()
        {
            var result = await _busService.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpGet("GetBusById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _busService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPost("SaveBus")]
        public async Task<IActionResult> Post([FromBody] BusSaveDto busSaveDto)
        {
            var result = await _busService.SaveAsync(busSaveDto); 

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<BusController>/5
        [HttpPut("UpdateBus")]
        public async Task<IActionResult> Put([FromBody] BusUpdateDto busUpdate)
        {
            var result = await _busService.UpdateAsync(busUpdate);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
