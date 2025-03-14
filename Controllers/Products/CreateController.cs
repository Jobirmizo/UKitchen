using Microsoft.AspNetCore.Mvc;

namespace UniversityKitchen.Controllers.Products;

public class CreateController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
}