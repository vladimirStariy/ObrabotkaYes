using Microsoft.AspNetCore.Mvc;
using ObrabotkaYes.Service.Interfaces;

namespace ObrabotkaYes.Areas.AdminArea.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
