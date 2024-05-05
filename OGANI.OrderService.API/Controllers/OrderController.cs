using Microsoft.AspNetCore.Mvc;
using OGANI.OrderService.Domain.Interfaces;
using OGANI.OrderService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OGANI.OrderService.API.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByOrderId(int id)
        {
            var order = await _orderService.GetOrderByOrderId(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound();
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<Order>> GetOrderByUserId(int id)
        {
            var order = await _orderService.GetOrdersByUserId(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
        {
           var createdOrder= await _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(CreateOrder), createdOrder);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Id doesnt match with the orderId");
            }

            await _orderService.UpdateOrder(order);
            return NoContent();

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
           var isSuccess = await _orderService.CancelOrder(id);
            if (!isSuccess)
            {
                return NotFound();

            }
            return NotFound();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var isSuccess= await _orderService.DeleteOrder(id);
            if (!isSuccess)
            {
                return NotFound();

            }
            return NotFound();

        }


    }
}

