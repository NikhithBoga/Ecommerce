using Ecommerce.Aspects;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OrderExceptionHandler]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderService.GetOrders());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_orderService.GetOrder(id));
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            return StatusCode(201, _orderService.AddOrder(order));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Order order)
        {
            return Ok(_orderService.UpdateOrder(id, order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_orderService.DeleteOrder(id));
        }
    }
}
