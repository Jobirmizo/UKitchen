using Microsoft.AspNetCore.Mvc;

namespace UniversityKitchen.Controllers.Customers;

public class CustomersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}