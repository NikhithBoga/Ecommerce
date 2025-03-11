using Ecommerce.Aspects;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OrderItemExceptionHandler]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderItemService.GetOrderItems());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_orderItemService.GetOrderItem(id));
        }

        [HttpPost]
        public IActionResult Post(OrderItem orderItem)
        {
            return StatusCode(201, _orderItemService.AddOrderItem(orderItem));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderItem orderItem)
        {
            return Ok(_orderItemService.UpdateOrderItem(id, orderItem));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_orderItemService.DeleteOrderItem(id));
        }
    }
}
