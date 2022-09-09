using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObrabotkaYes.Domain.ViewModels;
using ObrabotkaYes.Service.Interfaces;

namespace ObrabotkaYes.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderTypesService _orderTypesService;

        public OrderController(IOrderService orderService, IOrderTypesService orderTypesService)
        {
            _orderService = orderService;
            _orderTypesService = orderTypesService;
        }

        [HttpGet]
        public IActionResult Orders()
        {
            var response = _orderService.GetOrders();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("Orders", response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> OrderAdd()
        {
            var response = _orderTypesService.GetAll();
            ViewBag.OrderTypes = new SelectList(response.Result, "Type_ID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderAdd(OrderViewModel model)
        {
            var response = await _orderService.Create(model);
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
