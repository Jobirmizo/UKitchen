using Microsoft.AspNetCore.Mvc;

namespace UniversityKitchen.Controllers.Menu;

public class MenuController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}