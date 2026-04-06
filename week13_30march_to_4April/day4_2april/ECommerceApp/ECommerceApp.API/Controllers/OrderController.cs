using ECommerceApp.Core.DTOs.Order;
using ECommerceApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // ADMIN - see all orders
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        [HttpGet("all")]
[Authorize(Roles = "Admin")]
public async Task<IActionResult> GetAllOrders()
{
    var orders = await _orderService.GetAllOrdersAsync();
    return Ok(orders);
}

        // ADMIN - get any order by id
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound(new { message = "Order not found" });
            return Ok(order);
        }

        // USER - get their own orders using JWT token
        [HttpGet("myorders")]
        public async Task<IActionResult> GetMyOrders()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim);
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        // USER - place an order
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Get userId from JWT token automatically
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            var created = await _orderService.CreateOrderAsync(dto, int.Parse(userIdClaim));
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // ADMIN - update order status
        [HttpPatch("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            var validStatuses = new[] { "Pending", "Confirmed", "Shipped", "Delivered" };
            if (!validStatuses.Contains(status))
                return BadRequest(new { message = "Invalid status. Use: Pending, Confirmed, Shipped, Delivered" });

            var result = await _orderService.UpdateOrderStatusAsync(id, status);
            if (!result) return NotFound(new { message = "Order not found" });
            return Ok(new { message = $"Order status updated to {status}" });
        }

        // ADMIN - delete order
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (!result) return NotFound(new { message = "Order not found" });
            return Ok(new { message = "Order deleted successfully" });
        }
    }
}
