using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Services.Interfaces;
namespace transport_logistics_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound($"Order with id: {id} not found");
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderCreateDto dto)
        {
            var createdOrderDto = await _orderService.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdOrderDto.Id }, createdOrderDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderCreateDto dto)
        {
            var success = await _orderService.Update(id, dto);

            if (!success)
            {
                return NotFound($"Order with id: {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _orderService.Delete(id);

            if (!success)
            {
                return NotFound($"Order with id: {id} not found");
            }

            return NoContent();
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> CompleteOrder(int id)
        {
            try
            {
                var succsess = await _orderService.CompleteOrderAsync(id);

                if (!succsess)
                {
                    return NotFound($"Order with id: {id} not found");
                }

                return NoContent();
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
