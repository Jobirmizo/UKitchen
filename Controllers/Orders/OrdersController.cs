using Microsoft.AspNetCore.Mvc;

namespace UniversityKitchen.Controllers.Orders;

public class OrdersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}