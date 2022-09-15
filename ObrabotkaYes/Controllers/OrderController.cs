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
        private readonly ICategoryService _categoryService;

        public OrderController(IOrderService orderService, IOrderTypesService orderTypesService, ICategoryService categoryService)
        {
            _orderService = orderService;
            _orderTypesService = orderTypesService;
            _categoryService = categoryService;
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
            var responseTypes = _orderTypesService.GetAll();
            ViewBag.OrderTypes = new SelectList(responseTypes.Result, "Type_ID", "Name");
            var responseCategories = _categoryService.GetCategories();
            ViewBag.Categories = new SelectList(responseCategories.Result, "Category_ID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderAdd(OrderViewModel model, List<IFormFile> files)
        {
            Console.WriteLine(Request.Form);
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
