using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Services.Interfaces;
namespace transport_logistics_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripLogController : ControllerBase
    {
        private readonly ITripLogService _tripLogService;

        public TripLogController(ITripLogService tripLogService)
        {
            _tripLogService = tripLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tripLogs = await _tripLogService.GetAllAsync();
            return Ok(tripLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tripLog = await _tripLogService.GetByIdAsync(id);

            if (tripLog == null)
            {
                return NotFound($"Trip Log with id: {id} not found");
            }

            return Ok(tripLog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TripLogCreateDto dto)
        {
            var createdTripLogDto = await _tripLogService.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdTripLogDto.Id }, createdTripLogDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TripLogCreateDto dto)
        {
            var success = await _tripLogService.Update(id, dto);

            if (!success)
            {
                return NotFound($"Trip Log with id: {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _tripLogService.Delete(id);

            if (!success)
            {
                return NotFound($"Trip Log with id: {id} not found");
            }

            return NoContent();
        }
    }
}
