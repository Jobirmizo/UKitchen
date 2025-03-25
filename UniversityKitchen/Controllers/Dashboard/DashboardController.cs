using Microsoft.AspNetCore.Mvc;

namespace UniversityKitchen.Controllers.Dashboard;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}