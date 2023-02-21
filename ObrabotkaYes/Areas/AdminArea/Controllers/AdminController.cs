using Microsoft.AspNetCore.Mvc;

namespace ObrabotkaYes.Areas.AdminArea.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
