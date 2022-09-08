using Microsoft.AspNetCore.Mvc;
using ObrabotkaYes.Domain.ViewModels;
using ObrabotkaYes.Service.Interfaces;

namespace ObrabotkaYes.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Orders()
        {
            var response = _orderService.GetOrders();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult OrderAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderAdd(OrderViewModel model, IFormFileCollection uploads)
        {
            var response = await _orderService.Create(model, uploads);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Error", $"{response.Description}");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
