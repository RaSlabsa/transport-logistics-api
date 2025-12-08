using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Services.Interfaces;
namespace transport_logistics_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var drivers = await _driverService.GetAllAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var driver = await _driverService.GetByIdAsync(id);

            if (driver == null)
            {
                return NotFound($"Driver with id: {id} not found");
            }

            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DriverCreateDto dto)
        {
            var createdDriverDto = await _driverService.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdDriverDto.Id }, createdDriverDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DriverCreateDto dto)
        {
            var success = await _driverService.Update(id, dto);

            if (!success)
            {
                return NotFound($"Driver with id: {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _driverService.Delete(id);

            if (!success)
            {
                return NotFound($"Driver with id: {id} not found");
            }

            return NoContent();
        }
    }
}
