using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Services.Interfaces;
namespace transport_logistics_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound($"Client with id: {id} not found");
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientCreateDto dto)
        {
            var createdClientDto = await _clientService.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdClientDto.Id }, createdClientDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientCreateDto dto)
        {
            var success = await _clientService.Update(id, dto);

            if (!success)
            {
                return NotFound($"Client with id: {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _clientService.Delete(id);

            if (!success)
            {
                return NotFound($"Client with id: {id} not found");
            }

            return NoContent();
        }
    }
}
