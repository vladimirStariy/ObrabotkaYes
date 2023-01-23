using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Service.Implementations;
using ObrabotkaYes.Service.Interfaces;

namespace ObrabotkaYes.React.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ICollection<Order> Get()
        {
            var response = _orderService.GetOrders();
            return response.Result;
        }
    }
}
