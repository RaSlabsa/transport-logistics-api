using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Services.Interfaces;
namespace transport_logistics_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trips = await _tripService.GetAllAsync();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trip = await _tripService.GetByIdAsync(id);

            if (trip == null)
            {
                return NotFound($"Trip with id: {id} not found");
            }

            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TripCreateDto dto)
        {
            var createdTripDto = await _tripService.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdTripDto.Id }, createdTripDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TripCreateDto dto)
        {
            var success = await _tripService.Update(id, dto);

            if (!success)
            {
                return NotFound($"Trip with id: {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _tripService.Delete(id);

            if (!success)
            {
                return NotFound($"Trip with id: {id} not found");
            }

            return NoContent();
        }
    }
}
