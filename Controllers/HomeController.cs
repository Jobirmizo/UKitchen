using Microsoft.AspNetCore.Mvc;

namespace UniversityKitchen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Home()
        {
            return PartialView("Home/HomeContent");
        }

        public IActionResult Dashboard()
        {
            return PartialView("Dashboard/DashboardContent");
        }
    }
}