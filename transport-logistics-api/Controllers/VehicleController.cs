using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Services.Interfaces;
namespace transport_logistics_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);

            if (vehicle == null)
            {
                return NotFound($"Vehicle with id: {id} not found");
            }

            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleCreateDto dto)
        {
            var createdTripDto = await _vehicleService.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdTripDto.Id }, createdTripDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VehicleCreateDto dto)
        {
            var success = await _vehicleService.Update(id, dto);

            if (!success)
            {
                return NotFound($"Vehicle with id: {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _vehicleService.Delete(id);

            if (!success)
            {
                return NotFound($"Vehicle with id: {id} not found");
            }

            return NoContent();
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var available = await _vehicleService.GetAvailableVehiclesAsync();

            if (!available.Any())
            {
                return NoContent();
            }

            return Ok(available);
        }
    }
}
