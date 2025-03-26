using Microsoft.AspNetCore.Mvc;

namespace UniversityKitchen.Controllers.Home;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}